# Auth JWT

Desenvolvi esse projeto com a finalidade de aprender como funciona a autenticação com Json Web Token em uma aplicação. 

Basicamente, você cria seu usuário na interface do sistema e faz login normalmente, a API retornará o JWT para o Angular, com isso, o token é armazenado no LocalStorage do browser. 

Com o token armazenado a interface sabe que você está autenticado. Caso efetue o logout, o token será destruido e você terá de se logar novamente.

## Ferramentas e bibliotecas

Utilizei o banco de dados SQL Server.

Utilizei na API: 

- ASP.NET 5
- Entity Framework Core 5 (Code-First)
- Fluent Validation

Utilizei no Front-End:

- Angular 11
- Angular-Jwt https://www.npmjs.com/package/@auth0/angular-jwt
- Ng-Brazil https://www.npmjs.com/package/ng-brazil
- Ngx-Toastr https://www.npmjs.com/package/ngx-toastr

## Para rodar a API

- Clone o projeto para sua máquina.

- Abra a solution presente em ~\auth-jwt\Api\Solution\Auth no Visual Studio 2019

- Substitua a string de conexão do SQL Server presente no appsettings.json

- Após substituir a string de conexão, abra o projeto Auth.Data no terminal e execute o comando abaixo para rodar as migrations e criar as tabelas na base:

```bash
dotnet ef database update
```

- Execute a aplicação na porta 44357

## Para rodar o front-end

- Acesse a pasta ~\auth-jwt\Client\AuthWeb via terminal e execute o seguinte comando para baixar as dependências:

```bash
npm install
```

- Após ter baixado as dependências, rode o comando abaixo e abra o navegador na url "http://localhost:4200/"

```bash
ng serve
```

## License

[MIT License](https://lucasrufo.mit-license.org/) © Lucas Rufo
