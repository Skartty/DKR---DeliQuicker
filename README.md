# DKR---DeliQuicker
Projeto da faculdade - Segundo Semestre

## Descrição do Funcionamento do Código

Este projeto foi desenvolvido utilizando o **.NET Framework 4.8**, uma plataforma robusta da Microsoft para desenvolvimento de aplicações Windows. O código segue a arquitetura orientada a objetos, promovendo reutilização, manutenção e escalabilidade.

### Estrutura Geral

- **Camada de Apresentação (UI):** Responsável pela interação com o usuário, geralmente implementada com Windows Forms ou WPF.
- **Camada de Negócios (Business Logic):** Contém as regras de negócio e validações principais do sistema.
- **Camada de Dados (Data Access):** Realiza a comunicação com bancos de dados, utilizando tecnologias como ADO.NET ou Entity Framework.

### Principais Tecnologias Utilizadas

- **.NET Framework 4.8:** Plataforma base para execução da aplicação.
- **C#:** Linguagem principal utilizada para o desenvolvimento do código.
- **Entity Framework (opcional):** ORM para facilitar o acesso e manipulação de dados relacionais.
- **Windows Forms/WPF:** Frameworks para construção da interface gráfica (caso aplicável).
- **ADO.NET:** Biblioteca para acesso a dados relacionais (caso não utilize ORM).

### Funcionamento Básico

1. **Inicialização:** Ao iniciar, a aplicação carrega as configurações necessárias e prepara os componentes de interface.
2. **Interação do Usuário:** O usuário interage com a interface, acionando eventos (cliques, preenchimento de campos, etc.).
3. **Processamento:** As ações do usuário são processadas pela camada de negócios, que executa validações e regras.
4. **Persistência de Dados:** Quando necessário, os dados são salvos ou recuperados do banco de dados pela camada de acesso a dados.
5. **Resposta ao Usuário:** O resultado das operações é apresentado ao usuário, seja em forma de mensagens, atualizações de tela ou relatórios.

### Referências

- [.NET Framework 4.8 Documentation](https://learn.microsoft.com/dotnet/framework/)
- [C# Programming Guide](https://learn.microsoft.com/dotnet/csharp/)
- [Entity Framework Documentation](https://learn.microsoft.com/ef/)
- [ADO.NET Overview](https://learn.microsoft.com/dotnet/framework/data/adonet/)
- [Windows Forms Documentation](https://learn.microsoft.com/dotnet/desktop/winforms/)
- [WPF Documentation](https://learn.microsoft.com/dotnet/desktop/wpf/)
