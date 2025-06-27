# Memory Reader GUI - Professional Edition

Uma interface gráfica profissional para leitura e manipulação de memória de processos, desenvolvida especificamente para o jogo Conquer.

## 🚀 Características

- **Interface Moderna**: Design profissional com tema escuro
- **Conexão Inteligente**: Conecta automaticamente ao processo especificado
- **Monitoramento em Tempo Real**: Lista entidades com atualização contínua
- **Controle de Wall Jump**: Ativação/desativação global
- **Configuração de Offsets**: Interface intuitiva para personalização
- **Wiki Integrada**: Documentação completa e ajuda
- **Import/Export**: Backup e compartilhamento de configurações

## 📋 Requisitos

- Windows 10/11 (64-bit)
- .NET 6.0 ou superior
- Privilégios de administrador
- Processo alvo (Conquer.exe) em execução

## 🛠️ Compilação

### Pré-requisitos
- Visual Studio 2022 ou superior
- .NET 6.0 SDK
- Windows Forms Workload

### Passos para Compilar

1. **Clone ou baixe o projeto**
   ```
   git clone <repository-url>
   cd ProjectCarniato
   ```

2. **Restaurar dependências**
   ```
   dotnet restore
   ```

3. **Compilar o projeto**
   ```
   dotnet build --configuration Release
   ```

4. **Executar**
   ```
   dotnet run
   ```

### Compilação via Visual Studio

1. Abra o arquivo `ProjectCarniato.sln`
2. Selecione a configuração `Release`
3. Build > Build Solution (Ctrl+Shift+B)
4. Execute com F5 ou Ctrl+F5

## 📖 Como Usar

### Conexão Inicial

1. **Inicie o jogo** (Conquer.exe)
2. **Execute o Memory Reader GUI** como administrador
3. **Digite o nome do processo** ou use "Selecionar .exe"
4. **Clique em "Conectar"**
5. **Verifique o status** da conexão

### Monitoramento de Entidades

- As entidades aparecem automaticamente na lista
- Ajuste o número máximo conforme necessário
- Monitore posições e status em tempo real

### Controle de Wall Jump

- **Ativar**: Clique em "Ativar Wall Jump"
- **Desativar**: Clique em "Desativar Wall Jump"
- O status é mantido automaticamente

### Configuração de Offsets

1. Clique em "Configurar Offsets"
2. Edite os valores conforme necessário
3. Use formato hexadecimal (0x...) ou decimal
4. Salve as alterações

## 🔧 Configuração de Offsets

### Offsets Padrão (Conquer)

| Offset | Valor | Descrição |
|--------|-------|-----------|
| Entity List | 0x00194A0C | Lista de entidades |
| Name | 0x88 | Nome da entidade |
| Wall Jump | 0xFC | Controle de Wall Jump |
| Position X | 0x148 | Coordenada X |
| Position Y | 0x14C | Coordenada Y |

### Formatos Suportados

- **Hexadecimal**: `0x00194A0C` ou `194A0C`
- **Decimal**: `1657356`

## 📁 Estrutura do Projeto

```
ProjectCarniato/
├── Program.cs              # Ponto de entrada
├── MainForm.cs             # Interface principal
├── MemoryManager.cs        # Gerenciamento de memória
├── OffsetsForm.cs          # Configuração de offsets
├── WikiForm.cs             # Wiki e ajuda
├── ProjectCarniato.csproj  # Arquivo de projeto
└── README.md               # Este arquivo
```

## 🛡️ Segurança

- **Execute como administrador** para acesso à memória
- **Configure exceções no antivírus** se necessário
- **Use apenas em processos próprios**
- **Faça backup das configurações** antes de modificar

## 🐛 Solução de Problemas

### Não Consegue Conectar
- Verifique se o processo está rodando
- Execute como administrador
- Adicione exceção no antivírus
- Confirme o nome exato do processo

### Entidades Não Aparecem
- Verifique os offsets
- Aumente o número máximo de entidades
- Reset para valores padrão

### Wall Jump Não Funciona
- Confirme o offset correto
- Teste diferentes valores
- Mantenha o software ativo

## 📞 Suporte

Para suporte técnico, inclua sempre:
- Versão do Memory Reader GUI
- Versão do Windows
- Versão do jogo
- Descrição detalhada do problema
- Screenshots ou logs de erro

## 🤝 Contribuições

Contribuições são bem-vindas! Você pode:
- Reportar bugs e sugestões
- Compartilhar novos offsets
- Ajudar outros usuários
- Contribuir com código

## 📄 Licença

Este projeto é fornecido "como está" para fins educacionais e de pesquisa.

## ⚠️ Aviso Legal

- Use apenas em processos que você possui
- Respeite os termos de serviço dos jogos
- O desenvolvedor não se responsabiliza pelo uso indevido
- Mantenha backups de configurações importantes

---

**Memory Reader GUI v1.0** - Desenvolvido com ❤️ para a comunidade

