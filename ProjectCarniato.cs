using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace ProjectCarniato
{
    public class ProjectCarniato
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int dwSize, out int lpNumberOfBytesRead);

        [DllImport("kernel32.dll")]
        static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int dwSize, out int lpNumberOfBytesWritten);

        [DllImport("kernel32.dll")]
        static extern bool CloseHandle(IntPtr hObject);

        const int PROCESS_VM_READ = 0x0010;
        const int PROCESS_VM_WRITE = 0x0020;
        const int PROCESS_QUERY_INFORMATION = 0x0400;

        public IntPtr ProcessHandle { get; private set; }
        public IntPtr BaseAddress { get; private set; }
        public bool IsProcessConnected { get; private set; }
        public string ProcessName { get; private set; }


        public MemoryOffsets Offsets { get; set; }

        public ProjectCarniato()
        {
            Offsets = new MemoryOffsets();
        }

        public bool ConnectToProcess(string processName)
        {
            try
            {
                var processes = Process.GetProcessesByName(processName);
                if (processes.Length == 0)
                {
                    IsProcessConnected = false;
                    return false;
                }

                var process = processes[0];
                ProcessHandle = OpenProcess(PROCESS_VM_READ | PROCESS_VM_WRITE | PROCESS_QUERY_INFORMATION, false, process.Id);
                
                if (ProcessHandle == IntPtr.Zero)
                {
                    IsProcessConnected = false;
                    return false;
                }

                BaseAddress = process.MainModule.BaseAddress;
                ProcessName = processName;
                IsProcessConnected = true;
                return true;
            }
            catch
            {
                IsProcessConnected = false;
                return false;
            }
        }

        public void Disconnect()
        {
            if (ProcessHandle != IntPtr.Zero)
            {
                CloseHandle(ProcessHandle);
                ProcessHandle = IntPtr.Zero;
            }
            IsProcessConnected = false;
        }

        public List<GameEntity> GetEntities(int maxEntities)
        {
            var entities = new List<GameEntity>();
            
            if (!IsProcessConnected)
                return entities;

            try
            {
                IntPtr entityListAddress = ReadPointer(BaseAddress + Offsets.EntityListOffset);

                for (int i = 0; i < maxEntities; i++)
                {
                    IntPtr entityPtr = ReadPointer(entityListAddress + i * 4);
                    if (entityPtr == IntPtr.Zero)
                        continue;

                    string name = ReadString(entityPtr + Offsets.NameOffset, 16);
                    if (string.IsNullOrWhiteSpace(name))
                        continue;

                    var entity = new GameEntity
                    {
                        Index = i,
                        Name = name,
                        Address = entityPtr,
                        WallJumpValue = ReadInt(entityPtr + Offsets.WallJumpOffset),
                        PosX = ReadInt(entityPtr + Offsets.PosXOffset),
                        PosY = ReadInt(entityPtr + Offsets.PosYOffset)
                    };

                    entities.Add(entity);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao ler entidades: {ex.Message}");
            }

            return entities;
        }

        public bool SetWallJump(IntPtr entityAddress, int value)
        {
            if (!IsProcessConnected)
                return false;

            return WriteInt(entityAddress + Offsets.WallJumpOffset, value);
        }

        public bool SetWallJumpForAll(List<GameEntity> entities, int value)
        {
            if (!IsProcessConnected)
                return false;

            bool success = true;
            foreach (var entity in entities)
            {
                if (!SetWallJump(entity.Address, value))
                    success = false;
            }
            return success;
        }

        private IntPtr ReadPointer(IntPtr address)
        {
            byte[] buffer = new byte[4];
            ReadProcessMemory(ProcessHandle, address, buffer, buffer.Length, out _);
            return (IntPtr)BitConverter.ToInt32(buffer, 0);
        }

        private string ReadString(IntPtr address, int length)
        {
            byte[] buffer = new byte[length];
            ReadProcessMemory(ProcessHandle, address, buffer, buffer.Length, out _);
            int realLen = Array.IndexOf(buffer, (byte)0);
            if (realLen < 0) realLen = buffer.Length;
            return Encoding.ASCII.GetString(buffer, 0, realLen);
        }

        private int ReadInt(IntPtr address)
        {
            byte[] buffer = new byte[4];
            ReadProcessMemory(ProcessHandle, address, buffer, buffer.Length, out _);
            return BitConverter.ToInt32(buffer, 0);
        }

        private bool WriteInt(IntPtr address, int value)
        {
            byte[] buffer = BitConverter.GetBytes(value);
            return WriteProcessMemory(ProcessHandle, address, buffer, buffer.Length, out _);
        }

        ~ProjectCarniato()
        {
            Disconnect();
        }
    }

    public class MemoryOffsets
    {
        public int EntityListOffset { get; set; } = 0x00194A0C;
        public int NameOffset { get; set; } = 0x88;
        public int WallJumpOffset { get; set; } = 0xFC;
        public int PosXOffset { get; set; } = 0x148;
        public int PosYOffset { get; set; } = 0x14C;

        public MemoryOffsets Clone()
        {
            return new MemoryOffsets
            {
                EntityListOffset = this.EntityListOffset,
                NameOffset = this.NameOffset,
                WallJumpOffset = this.WallJumpOffset,
                PosXOffset = this.PosXOffset,
                PosYOffset = this.PosYOffset
            };
        }
    }

    public class GameEntity
    {
        public int Index { get; set; }
        public string Name { get; set; } = string.Empty;
        public IntPtr Address { get; set; }
        public int WallJumpValue { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
        public int LastPosX { get; set; }
        public int LastPosY { get; set; }

        public bool HasPositionChanged()
        {
            return PosX != LastPosX || PosY != LastPosY;
        }

        public void UpdateLastPosition()
        {
            LastPosX = PosX;
            LastPosY = PosY;
        }
    }
}

