# 🎓 Sistema Acadêmico - Blazor WebAssembly + .NET 8 + SQL Server

Este projeto é um sistema acadêmico desenvolvido com **Blazor WebAssembly**, **.NET 8**, **MudBlazor** e **SQL Server**, com o objetivo de gerenciar alunos, cursos, professores, notas, frequência e muito mais.

---

## 🔧 Tecnologias Utilizadas

- ⚙️ **.NET 8**
- 🌐 **Blazor WebAssembly (Client-side)**
- 🎨 **MudBlazor** - UI Component Library
- 🔌 **API REST** com Minimal APIs
- 🗄️ **Entity Framework Core**
- 🧩 **SQL Server** como banco de dados
- 📈 **Blazorise.Charts** para gráficos interativos

---

## 📁 Estrutura do Projeto

```
SistemaAcademico/
├── SistemaAcademico.API/            # Projeto da API REST com .NET 8
├── SistemaAcademico.Web/            # Projeto Blazor WebAssembly (frontend)
├── SistemaAcademico.Data/           # Modelos, DAL, e contexto EF
├── SistemaAcademico.Models/         # Entidades e Requests/DTOs
├── SistemaAcademico.Services/       # Serviços que consomem a API
```

---

## 📚 Funcionalidades

- ✅ CRUD completo de Alunos, Cursos, Professores e Notas
- 📊 Dashboard com gráficos:
  - Média de notas por curso
  - Quantidade de alunos por curso
- 📆 Registro de frequência por data
- 🔐 Organização via EndPoints por extensão
- 🔎 Paginação com MudPagination

---

## 📦 Como executar o projeto

### Pré-requisitos:

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- Visual Studio 2022 ou VS Code

### 1. Clone o repositório:

```bash
git clone https://github.com/seu-usuario/sistema-academico.git
cd sistema-academico
```

### 2. Configure o banco de dados

- Atualize a `connection string` no arquivo `appsettings.json` da API:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=SistemaAcademico;Trusted_Connection=True;"
}
```

- Execute as migrações (caso use EF Core Migrations):

```bash
cd SistemaAcademico.API
dotnet ef database update
```

### 3. Execute o projeto:

```bash
dotnet run --project SistemaAcademico.API
dotnet run --project SistemaAcademico.Web
```

## 🧑‍💻 Autor

Desenvolvido por **Gustavo Costa Vaz Garcia**  
📧 [gustavo.cvg@gmail.com](mailto:gustavocostagarcia13@gmail.com)  
🔗 [LinkedIn](www.linkedin.com/in/gustavo-costa-vaz-garcia-4807b9229)  
🐙 [GitHub](https://github.com/GustavoCosta2201)

---

## 📃 Licença

Este projeto está licenciado sob a **MIT License**.
