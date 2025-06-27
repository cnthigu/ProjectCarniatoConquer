using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;

namespace ProjectCarniato
{
    public partial class MainForm : Form
    {
        private ProjectCarniato memoryManager;
        private System.Windows.Forms.Timer updateTimer;
        private List<GameEntity> currentEntities;
        private bool wallJumpEnabled = false;

        private GroupBox processGroupBox;
        private TextBox processNameTextBox;
        private Button connectButton;
        private Button selectExecutableButton;
        private Label connectionStatusLabel;

        private GroupBox entitiesGroupBox;
        private ListBox entitiesListBox;
        private Label entitiesCountLabel;
        private NumericUpDown maxEntitiesNumeric;

        private GroupBox wallJumpGroupBox;
        private Button enableWallJumpButton;
        private Button disableWallJumpButton;
        private Label wallJumpStatusLabel;

        private GroupBox controlsGroupBox;
        private Button offsetsButton;
        private Button wikiButton;
        private Button contactButton;
        private Button youtubeButton;
        private Button githubButton; 

        public MainForm()
        {
            InitializeComponent();
            InitializeMemoryManager();
            SetupUpdateTimer();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            this.Text = "Project Carniato";
            this.Size = new Size(800, 650);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.FromArgb(45, 45, 48);
            this.ForeColor = Color.White;

            CreateProcessControls();
            CreateEntitiesControls();
            CreateWallJumpControls();
            CreateControlsGroup();

            this.ResumeLayout(false);
        }

        private void CreateProcessControls()
        {
            processGroupBox = new GroupBox
            {
                Text = "Conexão com Processo",
                Location = new Point(20, 20),
                Size = new Size(360, 120),
                ForeColor = Color.LightBlue,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            processNameTextBox = new TextBox
            {
                Location = new Point(15, 30),
                Size = new Size(200, 25),
                Text = "Conquer",
                BackColor = Color.FromArgb(60, 60, 60),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9)
            };

            connectButton = new Button
            {
                Text = "Conectar",
                Location = new Point(225, 28),
                Size = new Size(80, 30),
                BackColor = Color.FromArgb(0, 122, 204),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };
            connectButton.FlatAppearance.BorderSize = 0;
            connectButton.Click += ConnectButton_Click;

            selectExecutableButton = new Button
            {
                Text = "Selecionar .exe",
                Location = new Point(15, 65),
                Size = new Size(120, 30),
                BackColor = Color.FromArgb(70, 70, 70),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9)
            };
            selectExecutableButton.FlatAppearance.BorderSize = 0;
            selectExecutableButton.Click += SelectExecutableButton_Click;

            connectionStatusLabel = new Label
            {
                Text = "Desconectado",
                Location = new Point(145, 72),
                Size = new Size(200, 20),
                ForeColor = Color.Orange,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };

            processGroupBox.Controls.AddRange(new Control[] {
                processNameTextBox, connectButton, selectExecutableButton, connectionStatusLabel
            });

            this.Controls.Add(processGroupBox);
        }

        private void CreateEntitiesControls()
        {
            entitiesGroupBox = new GroupBox
            {
                Text = "Entidades Detectadas",
                Location = new Point(400, 20),
                Size = new Size(360, 300),
                ForeColor = Color.LightGreen,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            entitiesListBox = new ListBox
            {
                Location = new Point(15, 30),
                Size = new Size(330, 200),
                BackColor = Color.FromArgb(30, 30, 30),
                ForeColor = Color.White,
                Font = new Font("Consolas", 9),
                BorderStyle = BorderStyle.FixedSingle
            };

            entitiesCountLabel = new Label
            {
                Text = "Entidades: 0",
                Location = new Point(15, 240),
                Size = new Size(150, 20),
                ForeColor = Color.LightGray,
                Font = new Font("Segoe UI", 9)
            };

            var maxEntitiesLabel = new Label
            {
                Text = "Máx. Entidades:",
                Location = new Point(15, 265),
                Size = new Size(100, 20),
                ForeColor = Color.LightGray,
                Font = new Font("Segoe UI", 9)
            };

            maxEntitiesNumeric = new NumericUpDown
            {
                Location = new Point(120, 263),
                Size = new Size(80, 25),
                Minimum = 1,
                Maximum = 100,
                Value = 20,
                BackColor = Color.FromArgb(60, 60, 60),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9)
            };

            entitiesGroupBox.Controls.AddRange(new Control[] {
                entitiesListBox, entitiesCountLabel, maxEntitiesLabel, maxEntitiesNumeric
            });

            this.Controls.Add(entitiesGroupBox);
        }

        private void CreateWallJumpControls()
        {
            wallJumpGroupBox = new GroupBox
            {
                Text = "Controle de Wall Jump",
                Location = new Point(20, 160),
                Size = new Size(360, 120),
                ForeColor = Color.LightCoral,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            enableWallJumpButton = new Button
            {
                Text = "Ativar Wall Jump",
                Location = new Point(15, 30),
                Size = new Size(130, 35),
                BackColor = Color.FromArgb(0, 150, 0),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };
            enableWallJumpButton.FlatAppearance.BorderSize = 0;
            enableWallJumpButton.Click += EnableWallJumpButton_Click;

            disableWallJumpButton = new Button
            {
                Text = "Desativar Wall Jump",
                Location = new Point(155, 30),
                Size = new Size(130, 35),
                BackColor = Color.FromArgb(150, 0, 0),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };
            disableWallJumpButton.FlatAppearance.BorderSize = 0;
            disableWallJumpButton.Click += DisableWallJumpButton_Click;

            wallJumpStatusLabel = new Label
            {
                Text = "Status: Desativado",
                Location = new Point(15, 80),
                Size = new Size(200, 20),
                ForeColor = Color.Orange,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };

            wallJumpGroupBox.Controls.AddRange(new Control[] {
                enableWallJumpButton, disableWallJumpButton, wallJumpStatusLabel
            });

            this.Controls.Add(wallJumpGroupBox);
        }

        private void CreateControlsGroup()
        {
            controlsGroupBox = new GroupBox
            {
                Text = "Configurações e Ajuda",
                Location = new Point(20, 300),
                Size = new Size(360, 120),
                ForeColor = Color.LightYellow,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            offsetsButton = new Button
            {
                Text = "Configurar Offsets",
                Location = new Point(15, 30),
                Size = new Size(100, 35),
                BackColor = Color.FromArgb(100, 100, 100),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };
            offsetsButton.FlatAppearance.BorderSize = 0;
            offsetsButton.Click += OffsetsButton_Click;

            wikiButton = new Button
            {
                Text = "Wiki / Ajuda",
                Location = new Point(125, 30),
                Size = new Size(95, 35),
                BackColor = Color.FromArgb(70, 130, 180),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };
            wikiButton.FlatAppearance.BorderSize = 0;
            wikiButton.Click += WikiButton_Click;

            contactButton = new Button
            {
                Text = "Contato",
                Location = new Point(230, 30),
                Size = new Size(105, 35),
                BackColor = Color.FromArgb(128, 0, 128),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };
            contactButton.FlatAppearance.BorderSize = 0;
            contactButton.Click += ContactButton_Click;

            youtubeButton = new Button
            {
                Text = "YouTube",
                Location = new Point(15, 75),
                Size = new Size(100, 35),
                BackColor = Color.FromArgb(255, 0, 0),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };
            youtubeButton.FlatAppearance.BorderSize = 0;
            youtubeButton.Click += YoutubeButton_Click;


            githubButton = new Button
            {
                Text = "GitHub",
                Location = new Point(125, 75),
                Size = new Size(100, 35),
                BackColor = Color.FromArgb(50, 50, 50), 
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };
            githubButton.FlatAppearance.BorderSize = 0;
            githubButton.Click += GithubButton_Click;



            controlsGroupBox.Controls.AddRange(new Control[] {
                offsetsButton, wikiButton, contactButton, youtubeButton, githubButton,
            });

            this.Controls.Add(controlsGroupBox);
        }

        private void InitializeMemoryManager()
        {
            memoryManager = new ProjectCarniato();
            currentEntities = new List<GameEntity>();
        }

        private void SetupUpdateTimer()
        {
            updateTimer = new System.Windows.Forms.Timer
            {
                Interval = 100 
            };
            updateTimer.Tick += UpdateTimer_Tick;
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            string processName = processNameTextBox.Text.Trim();
            if (string.IsNullOrEmpty(processName))
            {
                MessageBox.Show("Por favor, insira o nome do processo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (memoryManager.ConnectToProcess(processName))
            {
                connectionStatusLabel.Text = "Conectado";
                connectionStatusLabel.ForeColor = Color.LightGreen;
                connectButton.Text = "Desconectar";
                connectButton.BackColor = Color.FromArgb(150, 0, 0);
                updateTimer.Start();
            }
            else
            {
                MessageBox.Show($"Não foi possível conectar ao processo '{processName}'.", "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SelectExecutableButton_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Executáveis (*.exe)|*.exe|Todos os arquivos (*.*)|*.*";
                openFileDialog.Title = "Selecionar Executável";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
                    processNameTextBox.Text = fileName;
                }
            }
        }

        private void EnableWallJumpButton_Click(object sender, EventArgs e)
        {
            if (!memoryManager.IsProcessConnected)
            {
                MessageBox.Show("Conecte-se a um processo primeiro.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (memoryManager.SetWallJumpForAll(currentEntities, 1))
            {
                wallJumpEnabled = true;
                wallJumpStatusLabel.Text = "Status: Ativado";
                wallJumpStatusLabel.ForeColor = Color.LightGreen;
            }
        }

        private void DisableWallJumpButton_Click(object sender, EventArgs e)
        {
            if (!memoryManager.IsProcessConnected)
            {
                MessageBox.Show("Conecte-se a um processo primeiro.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (memoryManager.SetWallJumpForAll(currentEntities, 0))
            {
                wallJumpEnabled = false;
                wallJumpStatusLabel.Text = "Status: Desativado";
                wallJumpStatusLabel.ForeColor = Color.Orange;
            }
        }

        private void OffsetsButton_Click(object sender, EventArgs e)
        {
            var offsetsForm = new OffsetsForm(memoryManager.Offsets);
            if (offsetsForm.ShowDialog() == DialogResult.OK)
            {
                memoryManager.Offsets = offsetsForm.GetOffsets();
            }
        }

        private void WikiButton_Click(object sender, EventArgs e)
        {
            var wikiForm = new WikiForm();
            wikiForm.ShowDialog();
        }

        private void ContactButton_Click(object sender, EventArgs e)
        {
            var wikiForm = new WikiForm();
            TabControl tabControl = null;
            foreach (Control control in wikiForm.Controls)
            {
                if (control is TabControl)
                {
                    tabControl = (TabControl)control;
                    break;
                }
            }

            if (tabControl != null)
            {
                foreach (TabPage tabPage in tabControl.TabPages)
                {
                    if (tabPage.Text == "Contato")
                    {
                        tabControl.SelectedTab = tabPage;
                        break;
                    }
                }
            }
            wikiForm.ShowDialog();
        }

        private void YoutubeButton_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "https://www.youtube.com/@CarniatoConquer",
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Não foi possível abrir o link: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void GithubButton_Click(object sender, EventArgs e)
        {
            try
            {

                Process.Start(new ProcessStartInfo
                {
                    FileName = "https://github.com/cnthigu",
                    UseShellExecute = true
                });

                MessageBox.Show(
                    "Se você gostou do projeto, por favor, considere dar uma estrela (★) no GitHub!\n\n" +
                    "Isso ajuda muito a divulgar o trabalho! ⭐",
                    "Apoie o Desenvolvedor!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Não foi possível abrir o link do GitHub: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            if (!memoryManager.IsProcessConnected)
            {
                updateTimer.Stop();
                connectionStatusLabel.Text = "Desconectado";
                connectionStatusLabel.ForeColor = Color.Orange;
                connectButton.Text = "Conectar";
                connectButton.BackColor = Color.FromArgb(0, 122, 204);
                return;
            }

            try
            {
                currentEntities = memoryManager.GetEntities((int)maxEntitiesNumeric.Value);
                UpdateEntitiesList();

                if (wallJumpEnabled)
                {
                    memoryManager.SetWallJumpForAll(currentEntities, 1);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro na atualização: {ex.Message}");
            }
        }

        private void UpdateEntitiesList()
        {
            entitiesListBox.Items.Clear();
            entitiesCountLabel.Text = $"Entidades: {currentEntities.Count}";

            foreach (var entity in currentEntities)
            {
                string displayText = $"[{entity.Index:D2}] {entity.Name} | WJ: {entity.WallJumpValue} | Pos: ({entity.PosX}, {entity.PosY})";
                entitiesListBox.Items.Add(displayText);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            updateTimer?.Stop();
            memoryManager?.Disconnect();
            base.OnFormClosing(e);
        }
    }
}