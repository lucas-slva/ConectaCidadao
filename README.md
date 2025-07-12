# ConectaCidadao 🎓

![.NET](https://img.shields.io/badge/.NET-9-512BD4?style=flat&logo=dotnet&logoColor=white)
![Clean Architecture](https://img.shields.io/badge/Architecture-Clean-blue?style=flat)
![EF Core](https://img.shields.io/badge/EF%20Core-In--Memory-512BD4?style=flat&logo=nuget&logoColor=white)
![xUnit](https://img.shields.io/badge/xUnit-Testing-5E97D0?style=flat&logo=nuget&logoColor=white)
![OpenAPI](https://img.shields.io/badge/OpenAPI-Docs-85EA2D?style=flat&logo=swagger&logoColor=white)

## 📖 **Visão Geral**
O **ConectaCidadao** é uma API RESTful para a curadoria e gestão de conteúdos sobre letramento digital. O projeto foi desenvolvido como parte da disciplina de **Atividade Extensionista II: Tecnologia Aplicada à Inclusão Digital**.

A aplicação foi construída utilizando os princípios da **Clean Architecture** para garantir um código desacoplado, testável e de fácil manutenção.

## 🚀 **Tecnologias Utilizadas**
- .NET 9
- ASP.NET Core Minimal API
- Entity Framework Core (com provedor In-Memory para desenvolvimento)
- Clean Architecture
- xUnit para testes (planejado)

## 🏗️ **Arquitetura do Projeto**
O projeto segue uma arquitetura modular e escalável baseada nos princípios da **Clean Architecture**, separando as responsabilidades em camadas bem definidas.

```plaintext
/
├── src/
│   ├── ConectaCidadao.API            # Ponto de entrada (Minimal API, injeção de dependência)
│   ├── ConectaCidadao.Application    # Lógica de negócio e contratos (interfaces, DTOs)
│   ├── ConectaCidadao.Domain         # Camada de domínio principal (entidades)
│   └── ConectaCidadao.Infrastructure # Acesso a dados (EF Core, DbContext)
│
└── tests/
    ├── ConectaCidadao.Application.Tests # Testes unitários da camada de aplicação
    └── ConectaCidadao.Domain.Tests      # Testes unitários da camada de domínio
```

## 🔧 **Como Executar o Projeto**
### Pré-requisitos:
- .NET SDK 9.0 ou superior

### Rodando a API:
```bash
# 1. Clone o repositório
git clone [https://github.com/lucas-slva/ConectaCidadao.git](https://github.com/lucas-slva/ConectaCidadao.git)
cd ConectaCidadao

# 2. Compile o projeto
dotnet build

# 3. Execute a API
dotnet run --project src/ConectaCidadao.API
```
Após executar, a API estará disponível em `http://localhost:5120`. A documentação interativa pode ser acessada em `http://localhost:5120/swagger`.

## 🎯 **API Endpoints**
### Status Atual
- `GET /api/conteudos` - Retorna uma lista de todos os conteúdos educacionais.

### Endpoints Planejados
- `GET /api/conteudos/{id}` - Busca um conteúdo por seu ID.
- `POST /api/conteudos` - Cria um novo conteúdo educacional.
- `PUT /api/conteudos/{id}` - Atualiza um conteúdo existente.
- `DELETE /api/conteudos/{id}` - Deleta um conteúdo.

## 📈 **Próximas Etapas e Funcionalidades Planejadas**
- [ ] **Implementação do CRUD Completo:** Finalizar os endpoints de POST, PUT e DELETE.
- [ ] **Validação de Dados:** Adicionar validação para os dados de entrada usando FluentValidation.
- [ ] **Testes Unitários:** Implementar os testes de unidade com xUnit para as camadas de Domínio e Aplicação.
- [ ] **Persistência de Dados:** Migrar do provedor In-Memory para um banco de dados persistente (SQLite ou PostgreSQL).
- [ ] **Autenticação e Autorização:** Implementar segurança nos endpoints com JWT.
