using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProjectCarniato
{
    public partial class WikiForm : Form
    {
        private TabControl tabControl;
        private TabPage offsetsTabPage;
        private TabPage functionsTabPage;
        private TabPage contactTabPage;
        private TabPage troubleshootingTabPage;

        public WikiForm()
        {
            InitializeComponent();
            LoadContent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            this.Text = "Project Carniato version 1.0 - Wiki e Ajuda";
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.BackColor = Color.FromArgb(45, 45, 48);
            this.ForeColor = Color.White;
            this.MinimumSize = new Size(600, 400);

            CreateTabControl();

            this.ResumeLayout(false);
        }

        private void CreateTabControl()
        {
            tabControl = new TabControl
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(45, 45, 48),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };

            offsetsTabPage = new TabPage("Offsets de Memória")
            {
                BackColor = Color.FromArgb(45, 45, 48),
                ForeColor = Color.White
            };


            functionsTabPage = new TabPage("Funcionalidades")
            {
                BackColor = Color.FromArgb(45, 45, 48),
                ForeColor = Color.White
            };


            contactTabPage = new TabPage("Contato")
            {
                BackColor = Color.FromArgb(45, 45, 48),
                ForeColor = Color.White
            };

            troubleshootingTabPage = new TabPage("Solução de Problemas")
            {
                BackColor = Color.FromArgb(45, 45, 48),
                ForeColor = Color.White
            };

            tabControl.TabPages.AddRange(new TabPage[] {
                functionsTabPage, offsetsTabPage, troubleshootingTabPage, contactTabPage
            });

            this.Controls.Add(tabControl);
        }

        private void LoadContent()
        {
            LoadFunctionsContent();
            LoadOffsetsContent();
            LoadTroubleshootingContent();
            LoadContactContent();
        }

        private void LoadFunctionsContent()
        {
            var panel = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = Color.FromArgb(45, 45, 48)
            };

            var content = new RichTextBox
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(30, 30, 30),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10),
                ReadOnly = true,
                BorderStyle = BorderStyle.None,
                Text = @"Project Carniato version 1.0 - GUIA DE FUNCIONALIDADES

                    ═══════════════════════════════════════════════════════════════

                    VISÃO GERAL
                    O Project Carniato version 1.0 é uma ferramenta profissional para leitura e manipulação de memória de processos em tempo real. Desenvolvido especificamente para o jogo Conquer, permite monitoramento de entidades e controle de funcionalidades como Wall Jump.

                    ═══════════════════════════════════════════════════════════════

                    FUNCIONALIDADES PRINCIPAIS

                    1. CONEXÃO COM PROCESSO
                       • Conecta automaticamente ao processo especificado
                       • Suporte para seleção manual de executáveis
                       • Monitoramento em tempo real do status da conexão
                       • Reconexão automática em caso de desconexão

                    2. MONITORAMENTO DE ENTIDADES
                       • Lista todas as entidades detectadas no jogo
                       • Exibe nomes, posições (X, Y) e status de Wall Jump
                       • Configuração do número máximo de entidades monitoradas
                       • Atualização em tempo real (100ms de intervalo)

                    3. CONTROLE DE WALL JUMP
                       • Ativação/desativação global do Wall Jump
                       • Aplicação automática para todas as entidades
                       • Status visual do estado atual
                       • Manutenção automática do estado ativo

                    4. CONFIGURAÇÃO DE OFFSETS
                       • Interface intuitiva para edição de offsets de memória
                       • Suporte para formatos hexadecimal e decimal
                       • Importação/exportação de configurações
                       • Reset para valores padrão
                       • Validação de entrada de dados

                    ═══════════════════════════════════════════════════════════════

                    COMO USAR

                    PASSO 1: CONEXÃO
                    1. Digite o nome do processo (padrão: 'Conquer')
                    2. Ou use 'Selecionar .exe' para escolher o executável
                    3. Clique em 'Conectar'
                    4. Verifique o status da conexão

                    PASSO 2: MONITORAMENTO
                    1. Ajuste o número máximo de entidades se necessário
                    2. Observe a lista de entidades detectadas
                    3. Monitore as posições e status em tempo real

                    PASSO 3: CONTROLE DE WALL JUMP
                    1. Clique em 'Ativar Wall Jump' para habilitar
                    2. Clique em 'Desativar Wall Jump' para desabilitar
                    3. O status será mantido automaticamente

                    PASSO 4: CONFIGURAÇÕES AVANÇADAS
                    1. Use 'Configurar Offsets' para ajustar endereços de memória
                    2. Consulte esta wiki para informações detalhadas
                    3. Exporte/importe configurações conforme necessário

                    ═══════════════════════════════════════════════════════════════

                    RECURSOS AVANÇADOS

                    • Interface responsiva com design profissional
                    • Cores temáticas para melhor experiência visual
                    • Tooltips informativos em controles importantes
                    • Tratamento robusto de erros e exceções
                    • Logs detalhados para diagnóstico
                    • Suporte para múltiplas configurações de offset

                    ═══════════════════════════════════════════════════════════════

                    AVISOS IMPORTANTES

                    • Use apenas em processos que você possui
                    • Backup suas configurações antes de modificar offsets
                    • O software requer privilégios administrativos
                    • Feche outros programas de monitoramento para evitar conflitos
                    • Mantenha o antivírus atualizado e configure exceções se necessário"
            };

            panel.Controls.Add(content);
            functionsTabPage.Controls.Add(panel);
        }

        private void LoadOffsetsContent()
        {
            var panel = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = Color.FromArgb(45, 45, 48)
            };

            var content = new RichTextBox
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(30, 30, 30),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10),
                ReadOnly = true,
                BorderStyle = BorderStyle.None,
                Text = @"OFFSETS DE MEMÓRIA - GUIA TÉCNICO

                        ═══════════════════════════════════════════════════════════════

                        O QUE SÃO OFFSETS?

                        Offsets são deslocamentos em bytes a partir de um endereço base na memória do processo. Eles indicam onde encontrar informações específicas sobre entidades do jogo, como nomes, posições e propriedades.

                        ═══════════════════════════════════════════════════════════════

                        OFFSETS PADRÃO (CONQUER)

                        Entity List Offset: 0x00194A0C
                        • Endereço base da lista de entidades
                        • Aponta para um array de ponteiros
                        • Cada ponteiro referencia uma entidade

                        Name Offset: 0x88 (136 decimal)
                        • Deslocamento para o nome da entidade
                        • String ASCII de até 16 caracteres
                        • Terminada em null (0x00)

                        Wall Jump Offset: 0xFC (252 decimal)
                        • Controla a capacidade de Wall Jump
                        • Valor 1 = Ativado, Valor 0 = Desativado
                        • Tipo: Integer de 32 bits

                        Position X Offset: 0x148 (328 decimal)
                        • Coordenada X da posição da entidade
                        • Valor em pixels ou unidades do jogo
                        • Tipo: Integer de 32 bits

                        Position Y Offset: 0x14C (332 decimal)
                        • Coordenada Y da posição da entidade
                        • Valor em pixels ou unidades do jogo
                        • Tipo: Integer de 32 bits

                        ═══════════════════════════════════════════════════════════════

                        COMO ENCONTRAR NOVOS OFFSETS

                        1. FERRAMENTAS NECESSÁRIAS
                           • Cheat Engine (recomendado)
                           • Process Hacker
                           • x64dbg (para análise avançada)

                        2. PROCESSO DE DESCOBERTA
                           • Anexe ao processo do jogo
                           • Procure por valores conhecidos (nome, posição)
                           • Use 'Next Scan' para refinar resultados
                           • Analise a estrutura da memória
                           • Teste a estabilidade dos offsets encontrados

                        3. VALIDAÇÃO
                           • Teste com múltiplas entidades
                           • Verifique após reiniciar o jogo
                           • Confirme que os valores fazem sentido
                           • Documente suas descobertas

                        ═══════════════════════════════════════════════════════════════

                        CUIDADOS IMPORTANTES

                        • Offsets podem mudar entre versões do jogo
                        • Sempre faça backup das configurações funcionais
                        • Teste em ambiente controlado antes do uso
                        • Valores incorretos podem causar crashes
                        • Mantenha documentação das suas modificações

                        ═══════════════════════════════════════════════════════════════

                        FORMATOS SUPORTADOS

                        HEXADECIMAL:
                        • 0x00194A0C (com prefixo)
                        • 194A0C (sem prefixo)

                        DECIMAL:
                        • 1657356 (conversão direta)

                        O software aceita ambos os formatos e converte automaticamente.

                        ═══════════════════════════════════════════════════════════════

                        IMPORTAÇÃO/EXPORTAÇÃO

                        FORMATO DO ARQUIVO:
                        EntityList=0x00194A0C
                        Name=0x88
                        WallJump=0xFC
                        PosX=0x148
                        PosY=0x14C

                        • Use este formato para compartilhar configurações
                        • Salve diferentes versões para diferentes updates do jogo
                        • Mantenha um arquivo master com configurações testadas"
            };

            panel.Controls.Add(content);
            offsetsTabPage.Controls.Add(panel);
        }

        private void LoadTroubleshootingContent()
        {
            var panel = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = Color.FromArgb(45, 45, 48)
            };

            var content = new RichTextBox
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(30, 30, 30),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10),
                ReadOnly = true,
                BorderStyle = BorderStyle.None,
                Text = @"SOLUÇÃO DE PROBLEMAS

                        ═══════════════════════════════════════════════════════════════

                        PROBLEMAS COMUNS E SOLUÇÕES

                        1. ""NÃO CONSEGUE CONECTAR AO PROCESSO""
   
                           Possíveis Causas:
                           • Processo não está em execução
                           • Nome do processo incorreto
                           • Falta de privilégios administrativos
                           • Antivírus bloqueando o acesso
   
                           Soluções:
                           • Verifique se o jogo está rodando
                           • Execute como Administrador
                           • Adicione exceção no antivírus
                           • Verifique o nome exato do processo no Task Manager

                        2. ""ENTIDADES NÃO APARECEM NA LISTA""
   
                           Possíveis Causas:
                           • Offsets incorretos ou desatualizados
                           • Versão do jogo incompatível
                           • Entidades fora do alcance configurado
   
                           Soluções:
                           • Verifique os offsets na configuração
                           • Aumente o número máximo de entidades
                           • Consulte offsets atualizados para sua versão
                           • Reset para valores padrão e teste

                        3. ""WALL JUMP NÃO FUNCIONA""
   
                           Possíveis Causas:
                           • Offset de Wall Jump incorreto
                           • Proteção do jogo ativa
                           • Valor sendo sobrescrito pelo jogo
   
                           Soluções:
                           • Verifique o offset de Wall Jump
                           • Teste com diferentes valores (0, 1, 2)
                           • Mantenha o software ativo para manutenção automática

                        4. ""APLICAÇÃO TRAVA OU FECHA""
   
                           Possíveis Causas:
                           • Acesso a memória inválida
                           • Conflito com outros programas
                           • Recursos insuficientes do sistema
   
                           Soluções:
                           • Feche outros programas de memória
                           • Reinicie o computador
                           • Execute apenas uma instância
                           • Verifique logs de erro no Windows

                        ═══════════════════════════════════════════════════════════════

                        DIAGNÓSTICO AVANÇADO

                        VERIFICAÇÃO DE PRIVILÉGIOS:
                        • Clique direito no executável
                        • Selecione ""Executar como administrador""
                        • Confirme no UAC (Controle de Conta de Usuário)

                        VERIFICAÇÃO DE PROCESSO:
                        • Abra o Task Manager (Ctrl+Shift+Esc)
                        • Vá para a aba ""Detalhes""
                        • Procure pelo processo do jogo
                        • Anote o nome exato (com .exe)

                        TESTE DE OFFSETS:
                        • Use Cheat Engine para verificar endereços
                        • Compare valores lidos com o esperado
                        • Teste com entidades conhecidas
                        • Documente resultados para referência

                        ═══════════════════════════════════════════════════════════════

                        CONFIGURAÇÕES DE SEGURANÇA

                        ANTIVÍRUS:
                        • Adicione exceção para o executável
                        • Adicione exceção para a pasta do programa
                        • Desative proteção em tempo real temporariamente
                        • Configure whitelist para processos conhecidos

                        FIREWALL:
                        • Permita comunicação local
                        • Adicione regra para o executável
                        • Verifique bloqueios de rede

                        WINDOWS DEFENDER:
                        • Vá para Configurações > Atualização e Segurança
                        • Selecione Segurança do Windows
                        • Proteção contra vírus e ameaças
                        • Adicionar exclusão

                        ═══════════════════════════════════════════════════════════════

                        QUANDO BUSCAR AJUDA

                        Entre em contato se:
                        • Problemas persistem após seguir este guia
                        • Encontrou bugs ou comportamentos inesperados
                        • Precisa de offsets para versões específicas
                        • Tem sugestões de melhorias
                        • Quer contribuir com o desenvolvimento

                        Forneça sempre:
                        • Versão do Windows
                        • Versão do jogo
                        • Mensagens de erro exatas
                        • Passos para reproduzir o problema
                        • Screenshots se relevante"
            };

            panel.Controls.Add(content);
            troubleshootingTabPage.Controls.Add(panel);
        }

        private void LoadContactContent()
        {
            var panel = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = Color.FromArgb(45, 45, 48)
            };

            var mainPanel = new Panel
            {
                Size = new Size(750, 500),
                Location = new Point(20, 20),
                BackColor = Color.FromArgb(45, 45, 48)
            };

            var titleLabel = new Label
            {
                Text = "INFORMAÇÕES DE CONTATO",
                Location = new Point(0, 0),
                Size = new Size(750, 40),
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.LightBlue,
                TextAlign = ContentAlignment.MiddleCenter
            };

            var devGroupBox = new GroupBox
            {
                Text = "Desenvolvedor",
                Location = new Point(0, 60),
                Size = new Size(360, 180),
                ForeColor = Color.LightGreen,
                Font = new Font("Segoe UI", 12, FontStyle.Bold)
            };

            var devInfo = new Label
            {
                Text = "Desenvolvedor Principal\n\n" +
                       "Email: higorzen77@gmail.com\n" +
                       "Discord: kingcnttt#2695\n" +
                       "GitHub: https://github.com/cnthigu\n",
                Location = new Point(15, 30),
                Size = new Size(330, 140),
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.White
            };

            devGroupBox.Controls.Add(devInfo);

            var communityGroupBox = new GroupBox
            {
                Text = "Comunidade",
                Location = new Point(380, 60),
                Size = new Size(360, 180),
                ForeColor = Color.LightCoral,
                Font = new Font("Segoe UI", 12, FontStyle.Bold)
            };

            var communityInfo = new Label
            {
                Text = "Servidor Discord\n" +
                       "discord.gg/S8HQnTXzkg\n\n" +
                       "youtube.com/@CarniatoConquer\n\n",
                Location = new Point(15, 30),
                Size = new Size(330, 140),
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.White
            };

            communityGroupBox.Controls.Add(communityInfo);


            var supportGroupBox = new GroupBox
            {
                Text = "Suporte Técnico",
                Location = new Point(0, 260),
                Size = new Size(740, 120),
                ForeColor = Color.LightYellow,
                Font = new Font("Segoe UI", 12, FontStyle.Bold)
            };

            var supportInfo = new Label
            {
                Text = "• Versão do Windows\n" +
                       "• Versão do jogo\n" +
                       "• Descrição detalhada do problema\n" +
                       "• Screenshots ou logs de erro\n\n",

                Location = new Point(15, 30),
                Size = new Size(710, 80),
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.White
            };

            supportGroupBox.Controls.Add(supportInfo);


            var contributionGroupBox = new GroupBox
            {
                Text = "Como Contribuir",
                Location = new Point(0, 400),
                Size = new Size(740, 80),
                ForeColor = Color.LightBlue,
                Font = new Font("Segoe UI", 12, FontStyle.Bold)
            };

            var contributionInfo = new Label
            {
                Text = "• Contribuições são bem-vindas!\n" +
                       "• Reporte bugs e sugestões\n" +
                       "• Compartilhe novos offsets\n" +
                       "• Ajude outros usuários na comunidade\n" +
                       "• Contribua com código no GitHub",
                Location = new Point(15, 25),
                Size = new Size(710, 50),
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.White
            };

            contributionGroupBox.Controls.Add(contributionInfo);

            mainPanel.Controls.AddRange(new Control[] {
                titleLabel, devGroupBox, communityGroupBox, supportGroupBox, contributionGroupBox
            });

            panel.Controls.Add(mainPanel);
            contactTabPage.Controls.Add(panel);
        }
    }
}

