# Carniato Project v 1.0

## Características

- **Conexão Inteligente**: Conecta automaticamente ao processo especificado
- **Monitoramento em Tempo Real**: Lista entidades com atualização contínua
- **Controle de Wall Jump**: Ativação/desativação global
- **Configuração de Offsets**: Interface intuitiva para personalização
- **Wiki Integrada**: Documentação completa e ajuda
- **Import/Export**: Backup e compartilhamento de configurações

### Compilação via Visual Studio

1. Abra o arquivo `ProjectCarniato.sln`
2. Selecione a configuração `Release`
3. Build > Build Solution (Ctrl+Shift+B)
4. Execute com F5 ou Ctrl+F5

## Como Usar

### Conexão Inicial

1. **Inicie o jogo** (Conquer.exe)
2. **Execute o Carniato Project v 1.0** como administrador
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

## Configuração de Offsets

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

## Estrutura do Projeto

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

## Contribuições

Contribuições são bem-vindas! Você pode:
- Reportar bugs e sugestões
- Compartilhar novos offsets
- Ajudar outros usuários
- Contribuir com código

## Aviso Legal

- Use apenas em processos que você possui
- Respeite os termos de serviço dos jogos
- O desenvolvedor não se responsabiliza pelo uso indevido
- Mantenha backups de configurações importantes

---

**Carniato Project v 1.0** - Considere Deixar uma Estrela!
