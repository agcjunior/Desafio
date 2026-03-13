# Desafio.Api

Este projeto é uma API desenvolvida em .NET 10 para o gerenciamento de autores, livros e gêneros literários.

## 🚀 Como Rodar o Projeto

O projeto utiliza **Docker Compose** para orquestrar o ambiente necessário, incluindo o banco de dados PostgreSQL e o pgAdmin.

### Pré-requisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [Docker](https://www.docker.com/get-started)
- [Docker Compose](https://docs.docker.com/compose/install/)

### Passo a Passo

1. **Clonar o Repositório**
   ```bash
   git clone <url-do-repositorio>
   cd Desafio
   ```

2. **Subir o Ambiente com Docker Compose**
   Na raiz do projeto (onde está o arquivo `docker-compose.yml`), execute:
   ```bash
   docker-compose up -d
   ```
   Isso iniciará os seguintes serviços:
   - **Desafio.Db**: Banco de dados PostgreSQL (Porta 5432).
   - **Desafio.Api**: A API principal (Portas 8080 e 8081).

3. **Acessar a API (Swagger)**
   Com os containers rodando, você pode acessar a documentação e testar os endpoints via Swagger em:
   - [http://localhost:8080/swagger](http://localhost:8080/swagger)
   - [https://localhost:8081/swagger](https://localhost:8081/swagger)

## 🛠️ Tecnologias Utilizadas

- **.NET 10**
- **Entity Framework Core** (Migrations automáticas ao iniciar em dev)
- **PostgreSQL**
- **Docker & Docker Compose**
- **MediatR** (Padrão CQRS)
- **FluentValidation**
- **Swagger/OpenAPI**

## 📂 Estrutura do Projeto

- `Desafio.Api`: Camada de entrada, controladores e configuração da API.
- `Desafio.Applicacao`: Regras de negócio, comandos, consultas e handlers (CQRS).
- `Desafio.Dominio`: Entidades e interfaces de repositórios.
- `Desafio.Infraestrutura`: Implementação de repositórios, contexto do banco e acesso a dados.
- `Desafio.Comum`: Utilitários, classes base e objetos de valor compartilhados.
