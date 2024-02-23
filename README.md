# ContatosApp API

Este é um projeto ASP.NET chamado ContatosApp, uma API para gerenciamento de contatos. A API utiliza o acesso ao banco de dados SQL Server através do Dapper para manipulação dos dados.

## Configuração do Banco de Dados

Antes de utilizar a API, é necessário criar um banco de dados no SQL Server chamado `BDContatosApp`. Em seguida, execute o arquivo `Script.sql` fornecido para criar as tabelas necessárias.

## Configuração da Connection String

Certifique-se de modificar a connection string na classe `ContatoRepository` para refletir as configurações do seu ambiente. A connection string padrão é:

```plaintext
Server=seu_servidor;Database=BDContatosApp;Trusted_Connection=True;

## Referências
Para mais informações sobre as tecnologias utilizadas neste projeto, consulte as seguintes documentações:

## Referências

Para mais informações sobre as tecnologias utilizadas neste projeto, consulte as seguintes documentações:

- [ASP.NET Web API](https://dotnet.microsoft.com/apps/aspnet/apis)
- [Dapper](https://dapper-tutorial.net/)
- [Swagger](https://swagger.io/)

Certifique-se de ter as seguintes bibliotecas/frameworks instalados:

- [ASP.NET Web API](https://dotnet.microsoft.com/apps/aspnet/apis)
- [Dapper](https://dapper-tutorial.net/)
- [Swagger](https://swagger.io/)
