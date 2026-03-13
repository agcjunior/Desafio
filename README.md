# Desafio.Api

Este projeto é uma API desenvolvida em .NET 10 para o gerenciamento de autores, livros e gêneros literários.

## 🏛️ Arquitetura da Solução

A solução segue os princípios da **Clean Architecture** e utiliza o padrão **CQRS** (Command Query Responsibility Segregation).

### Estrutura de Camadas:
- **`Desafio.Api`**: Camada de apresentação (ASP.NET Core Web API). Contém controladores, configurações e o pipeline de inicialização.
- **`Desafio.Applicacao`**: Camada de aplicação. Contém a lógica de negócio, comandos, consultas e handlers (MediatR + FluentValidation).
- **`Desafio.Dominio`**: Camada de domínio. Contém entidades, objetos de valor e interfaces.
- **`Desafio.Infraestrutura`**: Camada de infraestrutura. Implementa o acesso a dados com **Entity Framework Core** (Comandos/Escrita) e **Dapper** (Consultas/Leitura).
- **`Desafio.Comum`**: Camada transversal com utilitários e classes base.

## 🚀 Como Executar Localmente

### Pré-requisitos
- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [SQL Server LocalDB](https://learn.microsoft.com/pt-br/sql/database-engine/configure-windows/sql-server-express-localdb) (Instância: `(localdb)\mssqllocaldb`)

### Configuração e Execução

1. **Clonar o Repositório**
   ```bash
   git clone <url-do-repositorio>
   cd Desafio
   ```

2. **Executar a Aplicação**
   Basta rodar o comando abaixo na raiz do projeto:
   ```bash
   dotnet run --project Desafio.Api
   ```

### 🛠️ Inicialização Automática (Dev Mode)
Ao executar o projeto em modo de desenvolvimento (`Development`), a aplicação realiza automaticamente as seguintes operações via `Program.cs`:

- **Criação do Banco de Dados**: Verifica se o banco `DesafioDb` existe no LocalDB e o cria se necessário.
- **Migrações Automáticas**: Aplica todas as Migrations pendentes do Entity Framework (via `app.ApplyMigrations()`).
- **Seed de Dados**: Alimenta o banco com dados iniciais de teste para autores, gêneros e livros (via `app.SeedData()`).

> **Nota:** Se precisar gerenciar migrations manualmente, utilize o comando `dotnet ef database update -p Desafio.Infraestrutura -s Desafio.Api`.

### 📖 Documentação (Swagger)
Acesse a documentação interativa e teste os endpoints em:
- [http://localhost:5220/swagger](http://localhost:5220/swagger)
- [https://localhost:7205/swagger](https://localhost:7205/swagger)

## 🛠️ Tecnologias Utilizadas
- **.NET 10**
- **Entity Framework Core** (SQL Server)
- **Dapper**
- **MediatR**
- **FluentValidation**
- **Swagger/OpenAPI**
