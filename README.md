# TechLibrary

TechLibrary é uma API REST para gerenciamento de uma biblioteca, desenvolvida em .NET com arquitetura em camadas. O projeto centraliza o cadastro de livros, categorias, clientes e empréstimos, permitindo controlar o ciclo básico de uma operação bibliotecária: catalogar, consultar, emprestar, renovar e registrar devoluções.

## Objetivo

Fornecer uma API organizada e extensível para automatizar processos de biblioteca, reduzindo controles manuais e facilitando a consulta de informações sobre acervo, clientes e empréstimos.

## Público-Alvo

- Bibliotecas escolares, universitárias, comunitárias ou privadas.
- Desenvolvedores que precisam de uma base backend para sistemas de biblioteca.
- Estudantes que desejam estudar APIs REST com .NET, Entity Framework Core, SQL Server e separação por camadas.

## Problema que Resolve

Bibliotecas pequenas e médias geralmente enfrentam dificuldade para manter o controle de livros disponíveis, clientes cadastrados e histórico de empréstimos. O TechLibrary resolve esse problema ao oferecer uma API para:

- Organizar o acervo por categorias.
- Cadastrar e consultar clientes.
- Registrar empréstimos de livros.
- Controlar renovações e devoluções.
- Buscar informações externas de livros pela Open Library.

## Funcionalidades

- Cadastro, listagem, consulta, atualização e remoção de livros.
- Cadastro, listagem, consulta, atualização e remoção de categorias.
- Cadastro, listagem, consulta, atualização e remoção de clientes.
- Criação e consulta de empréstimos.
- Renovação de empréstimos.
- Registro de devolução de empréstimos.
- Consulta externa de livros por título usando a Open Library.
- Tratamento centralizado de exceções via middleware.
- Persistência de dados com Entity Framework Core e SQL Server.

## Tecnologias

- .NET 10
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- OpenAPI
- HttpClient
- Arquitetura em camadas:
  - `TechLibrary.API`
  - `TechLibrary.Application`
  - `TechLibrary.Domain`
  - `TechLibrary.Infrastructure`

## Estrutura do Projeto

```text
TechLibrary
├── TechLibrary.API              # Controllers, middlewares e configuração da API
├── TechLibrary.Application      # Casos de uso, serviços e DTOs
├── TechLibrary.Domain           # Entidades e interfaces de domínio
├── TechLibrary.Infrastructure   # Contexto EF Core, repositórios, mappings e migrations
└── TechLibrary.slnx             # Solution do projeto

```

## Endpoints

URL base em desenvolvimento:

```text
http://localhost:5033
https://localhost:7268
```

### Livros

| Metodo | Rota                                          | Descricao                               |
| ------ | --------------------------------------------- | --------------------------------------- |
| GET    | `/api/v1/Book`                                | Lista todos os livros                   |
| GET    | `/api/v1/Book/{id}`                           | Busca um livro por ID                   |
| POST   | `/api/v1/Book`                                | Cadastra um livro                       |
| PUT    | `/api/v1/Book/{id}`                           | Atualiza um livro                       |
| DELETE | `/api/v1/Book/{id}`                           | Remove um livro                         |
| GET    | `/api/v1/Book/external/search?title={titulo}` | Busca livros externos pela Open Library |

Exemplo de cadastro/atualizacao de livro:

```json
{
  "name": "Clean Code",
  "biography": "Livro sobre boas praticas de desenvolvimento de software.",
  "author": "Robert C. Martin",
  "publicationDate": "2008-08-01",
  "pageCount": 464,
  "categoryId": 1
}
```

### Categorias

| Metodo | Rota                    | Descricao                  |
| ------ | ----------------------- | -------------------------- |
| GET    | `/api/v1/Category`      | Lista todas as categorias  |
| GET    | `/api/v1/Category/{id}` | Busca uma categoria por ID |
| POST   | `/api/v1/Category`      | Cadastra uma categoria     |
| PUT    | `/api/v1/Category/{id}` | Atualiza uma categoria     |
| DELETE | `/api/v1/Category/{id}` | Remove uma categoria       |

Exemplo de cadastro/atualizacao de categoria:

```json
{
  "name": "Tecnologia"
}
```

### Clientes

| Metodo | Rota                    | Descricao               |
| ------ | ----------------------- | ----------------------- |
| GET    | `/api/v1/Customer`      | Lista todos os clientes |
| GET    | `/api/v1/Customer/{id}` | Busca um cliente por ID |
| POST   | `/api/v1/Customer`      | Cadastra um cliente     |
| PUT    | `/api/v1/Customer/{id}` | Atualiza um cliente     |
| DELETE | `/api/v1/Customer/{id}` | Remove um cliente       |

Exemplo de cadastro/atualizacao de cliente:

```json
{
  "firstName": "Maria",
  "lastName": "Silva",
  "phone": "11999999999",
  "email": "maria.silva@email.com",
  "cpf": "12345678900"
}
```

### Emprestimos

| Metodo | Rota                       | Descricao                             |
| ------ | -------------------------- | ------------------------------------- |
| GET    | `/api/v1/Loan`             | Lista todos os emprestimos            |
| GET    | `/api/v1/Loan/{id}`        | Busca um emprestimo por ID            |
| POST   | `/api/v1/Loan`             | Cria um emprestimo                    |
| PUT    | `/api/v1/Loan/{id}/return` | Registra a devolucao de um emprestimo |
| PUT    | `/api/v1/Loan/{id}/renew`  | Renova um emprestimo                  |

Exemplo de criacao de emprestimo:

```json
{
  "customerId": 1,
  "bookId": 1
}
```

## Como Executar o Projeto

### Pre-requisitos

- .NET SDK 10 ou superior
- SQL Server
- Entity Framework Core CLI

Para verificar a instalacao do .NET:

```bash
dotnet --version
```

Para instalar a ferramenta do Entity Framework Core, caso ainda nao esteja instalada:

```bash
dotnet tool install --global dotnet-ef
```

### Configurar a Connection String

Configure a connection string no arquivo `BibliotecaApp.API/appsettings.json` ou por User Secrets.

Exemplo usando User Secrets:

```bash
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=localhost;Database=BibliotecaAppDb;Trusted_Connection=True;TrustServerCertificate=True;" --project BibliotecaApp.API
```

### Restaurar Dependencias

```bash
dotnet restore BibliotecaApp.slnx
```

### Aplicar Migrations

```bash
dotnet ef database update --project BibliotecaApp.Infrastructure --startup-project BibliotecaApp.API
```

### Executar a API

```bash
dotnet run --project BibliotecaApp.API
```

Com o perfil HTTP, a API ficara disponivel em:

```text
http://localhost:5033
```

Em ambiente de desenvolvimento, a especificacao OpenAPI pode ser acessada em:

```text
http://localhost:5033/openapi/v1.json
```

## Fluxo Basico de Uso

1. Criar uma categoria em `/api/v1/Category`.
2. Criar um livro vinculado a categoria em `/api/v1/Book`.
3. Criar um cliente em `/api/v1/Customer`.
4. Criar um emprestimo em `/api/v1/Loan`.
5. Renovar ou registrar a devolucao do emprestimo quando necessario.

## Observações

- A API usa SQL Server como banco de dados.
- A busca externa de livros depende da disponibilidade da Open Library.
- O projeto possui migrations na camada `BibliotecaApp.Infrastructure`.
- A configuracao OpenAPI esta habilitada somente em ambiente de desenvolvimento.
