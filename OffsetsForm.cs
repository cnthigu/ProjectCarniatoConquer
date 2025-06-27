using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace ProjectCarniato
{
    public partial class OffsetsForm : Form
    {
        private MemoryOffsets offsets;
        private MemoryOffsets originalOffsets;

        private GroupBox offsetsGroupBox;
        private Label entityListLabel;
        private TextBox entityListTextBox;
        private Label nameLabel;
        private TextBox nameTextBox;
        private Label wallJumpLabel;
        private TextBox wallJumpTextBox;
        private Label posXLabel;
        private TextBox posXTextBox;
        private Label posYLabel;
        private TextBox posYTextBox;

        private GroupBox actionsGroupBox;
        private Button saveButton;
        private Button cancelButton;
        private Button resetButton;
        private Button importButton;
        private Button exportButton;

        private GroupBox helpGroupBox;
        private Label helpLabel;

        public OffsetsForm(MemoryOffsets currentOffsets)
        {
            originalOffsets = currentOffsets;
            offsets = currentOffsets.Clone();
            InitializeComponent();
            LoadOffsets();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            this.Text = "Configuração de Offsets de Memória";
            this.Size = new Size(500, 550);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.FromArgb(45, 45, 48);
            this.ForeColor = Color.White;

            CreateOffsetsControls();
            CreateActionsControls();
            CreateHelpControls();

            this.ResumeLayout(false);
        }

        private void CreateOffsetsControls()
        {
            offsetsGroupBox = new GroupBox
            {
                Text = "Offsets de Memória (Hexadecimal)",
                Location = new Point(20, 20),
                Size = new Size(440, 280),
                ForeColor = Color.LightBlue,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            entityListLabel = new Label
            {
                Text = "Entity List Offset:",
                Location = new Point(15, 35),
                Size = new Size(150, 20),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9)
            };

            entityListTextBox = new TextBox
            {
                Location = new Point(170, 33),
                Size = new Size(120, 25),
                BackColor = Color.FromArgb(60, 60, 60),
                ForeColor = Color.White,
                Font = new Font("Consolas", 9)
            };

            nameLabel = new Label
            {
                Text = "Name Offset:",
                Location = new Point(15, 70),
                Size = new Size(150, 20),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9)
            };

            nameTextBox = new TextBox
            {
                Location = new Point(170, 68),
                Size = new Size(120, 25),
                BackColor = Color.FromArgb(60, 60, 60),
                ForeColor = Color.White,
                Font = new Font("Consolas", 9)
            };

            wallJumpLabel = new Label
            {
                Text = "Wall Jump Offset:",
                Location = new Point(15, 105),
                Size = new Size(150, 20),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9)
            };

            wallJumpTextBox = new TextBox
            {
                Location = new Point(170, 103),
                Size = new Size(120, 25),
                BackColor = Color.FromArgb(60, 60, 60),
                ForeColor = Color.White,
                Font = new Font("Consolas", 9)
            };

            posXLabel = new Label
            {
                Text = "Position X Offset:",
                Location = new Point(15, 140),
                Size = new Size(150, 20),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9)
            };

            posXTextBox = new TextBox
            {
                Location = new Point(170, 138),
                Size = new Size(120, 25),
                BackColor = Color.FromArgb(60, 60, 60),
                ForeColor = Color.White,
                Font = new Font("Consolas", 9)
            };

            posYLabel = new Label
            {
                Text = "Position Y Offset:",
                Location = new Point(15, 175),
                Size = new Size(150, 20),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9)
            };

            posYTextBox = new TextBox
            {
                Location = new Point(170, 173),
                Size = new Size(120, 25),
                BackColor = Color.FromArgb(60, 60, 60),
                ForeColor = Color.White,
                Font = new Font("Consolas", 9)
            };

            var formatLabel = new Label
            {
                Text = "Formato: 0x00000000 ou apenas números hexadecimais",
                Location = new Point(15, 210),
                Size = new Size(400, 20),
                ForeColor = Color.LightGray,
                Font = new Font("Segoe UI", 8, FontStyle.Italic)
            };

            var exampleLabel = new Label
            {
                Text = "Exemplo: 0x00194A0C, 194A0C, ou 1657356",
                Location = new Point(15, 230),
                Size = new Size(400, 20),
                ForeColor = Color.LightGray,
                Font = new Font("Segoe UI", 8, FontStyle.Italic)
            };

            offsetsGroupBox.Controls.AddRange(new Control[] {
                entityListLabel, entityListTextBox,
                nameLabel, nameTextBox,
                wallJumpLabel, wallJumpTextBox,
                posXLabel, posXTextBox,
                posYLabel, posYTextBox,
                formatLabel, exampleLabel
            });

            this.Controls.Add(offsetsGroupBox);
        }

        private void CreateActionsControls()
        {
            actionsGroupBox = new GroupBox
            {
                Text = "Ações",
                Location = new Point(20, 320),
                Size = new Size(440, 80),
                ForeColor = Color.LightGreen,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            saveButton = new Button
            {
                Text = "Salvar",
                Location = new Point(15, 30),
                Size = new Size(80, 35),
                BackColor = Color.FromArgb(0, 150, 0),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                DialogResult = DialogResult.OK
            };
            saveButton.FlatAppearance.BorderSize = 0;
            saveButton.Click += SaveButton_Click;

            cancelButton = new Button
            {
                Text = "Cancelar",
                Location = new Point(105, 30),
                Size = new Size(80, 35),
                BackColor = Color.FromArgb(150, 0, 0),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                DialogResult = DialogResult.Cancel
            };
            cancelButton.FlatAppearance.BorderSize = 0;

            resetButton = new Button
            {
                Text = "Resetar",
                Location = new Point(195, 30),
                Size = new Size(80, 35),
                BackColor = Color.FromArgb(100, 100, 100),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };
            resetButton.FlatAppearance.BorderSize = 0;
            resetButton.Click += ResetButton_Click;

            importButton = new Button
            {
                Text = "Importar",
                Location = new Point(285, 30),
                Size = new Size(70, 35),
                BackColor = Color.FromArgb(70, 130, 180),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };
            importButton.FlatAppearance.BorderSize = 0;
            importButton.Click += ImportButton_Click;

            exportButton = new Button
            {
                Text = "Exportar",
                Location = new Point(365, 30),
                Size = new Size(70, 35),
                BackColor = Color.FromArgb(128, 0, 128),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };
            exportButton.FlatAppearance.BorderSize = 0;
            exportButton.Click += ExportButton_Click;

            actionsGroupBox.Controls.AddRange(new Control[] {
                saveButton, cancelButton, resetButton, importButton, exportButton
            });

            this.Controls.Add(actionsGroupBox);
        }

        private void CreateHelpControls()
        {
            helpGroupBox = new GroupBox
            {
                Text = "Informações",
                Location = new Point(20, 420),
                Size = new Size(440, 80),
                ForeColor = Color.LightYellow,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            helpLabel = new Label
            {
                Text = "Os offsets são endereços de memória que indicam onde encontrar\n" +
                       "informações específicas no processo. Modifique apenas se souber\n" +
                       "o que está fazendo. Valores incorretos podem causar instabilidade.",
                Location = new Point(15, 25),
                Size = new Size(410, 50),
                ForeColor = Color.LightGray,
                Font = new Font("Segoe UI", 8)
            };

            helpGroupBox.Controls.Add(helpLabel);
            this.Controls.Add(helpGroupBox);
        }

        private void LoadOffsets()
        {
            entityListTextBox.Text = $"0x{offsets.EntityListOffset:X8}";
            nameTextBox.Text = $"0x{offsets.NameOffset:X8}";
            wallJumpTextBox.Text = $"0x{offsets.WallJumpOffset:X8}";
            posXTextBox.Text = $"0x{offsets.PosXOffset:X8}";
            posYTextBox.Text = $"0x{offsets.PosYOffset:X8}";
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                offsets.EntityListOffset = ParseHexValue(entityListTextBox.Text);
                offsets.NameOffset = ParseHexValue(nameTextBox.Text);
                offsets.WallJumpOffset = ParseHexValue(wallJumpTextBox.Text);
                offsets.PosXOffset = ParseHexValue(posXTextBox.Text);
                offsets.PosYOffset = ParseHexValue(posYTextBox.Text);

                MessageBox.Show("Offsets salvos com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar offsets: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
            }
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Tem certeza que deseja resetar todos os offsets para os valores padrão?",
                "Confirmar Reset",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                offsets = new MemoryOffsets(); // Valores padrão
                LoadOffsets();
            }
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Arquivos de Offset (*.txt)|*.txt|Todos os arquivos (*.*)|*.*";
                openFileDialog.Title = "Importar Offsets";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string[] lines = System.IO.File.ReadAllLines(openFileDialog.FileName);
                        foreach (string line in lines)
                        {
                            if (line.StartsWith("EntityList="))
                                offsets.EntityListOffset = ParseHexValue(line.Substring(11));
                            else if (line.StartsWith("Name="))
                                offsets.NameOffset = ParseHexValue(line.Substring(5));
                            else if (line.StartsWith("WallJump="))
                                offsets.WallJumpOffset = ParseHexValue(line.Substring(9));
                            else if (line.StartsWith("PosX="))
                                offsets.PosXOffset = ParseHexValue(line.Substring(5));
                            else if (line.StartsWith("PosY="))
                                offsets.PosYOffset = ParseHexValue(line.Substring(5));
                        }
                        LoadOffsets();
                        MessageBox.Show("Offsets importados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao importar offsets: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Arquivos de Offset (*.txt)|*.txt|Todos os arquivos (*.*)|*.*";
                saveFileDialog.Title = "Exportar Offsets";
                saveFileDialog.FileName = "offsets.txt";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string[] lines = {
                            $"EntityList=0x{offsets.EntityListOffset:X8}",
                            $"Name=0x{offsets.NameOffset:X8}",
                            $"WallJump=0x{offsets.WallJumpOffset:X8}",
                            $"PosX=0x{offsets.PosXOffset:X8}",
                            $"PosY=0x{offsets.PosYOffset:X8}"
                        };
                        System.IO.File.WriteAllLines(saveFileDialog.FileName, lines);
                        MessageBox.Show("Offsets exportados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao exportar offsets: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private int ParseHexValue(string value)
        {
            value = value.Trim();
            
            // Remove prefixo 0x se presente
            if (value.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
                value = value.Substring(2);

            // Tenta converter como hexadecimal primeiro
            if (int.TryParse(value, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out int hexResult))
                return hexResult;

            // Se falhar, tenta como decimal
            if (int.TryParse(value, out int decResult))
                return decResult;

            throw new ArgumentException($"Valor inválido: {value}. Use formato hexadecimal (0x00000000) ou decimal.");
        }

        public MemoryOffsets GetOffsets()
        {
            return offsets;
        }
    }
}

