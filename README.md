# Developer Evaluation Project - Guia Rápido

API .NET 8 para gerenciamento de vendas usando EF Core e PostgreSQL.

---

**Pré-requisitos:**  
- .NET 8 SDK  
- Docker (opcional)  
- PostgreSQL (local ou via Docker)

---

**Passos para rodar o projeto:**

1. Clone o repositório:  
```
git clone https://github.com/seu-usuario/seu-repositorio.git
cd seu-repositorio
```

2. Configure a string de conexão no `appsettings.json`:  
```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=nome_do_banco;Username=usuario;Password=senha"
}
```

3. (Opcional) Suba o PostgreSQL com Docker:  
```
docker run --name developerstore-postgres -e POSTGRES_USER=usuario -e POSTGRES_PASSWORD=senha -e POSTGRES_DB=nome_do_banco -p 5432:5432 -d postgres
```

4. Aplique as migrations para criar as tabelas:  
```
dotnet ef database update --project ./src/Ambev.DeveloperEvaluation.ORM --startup-project ./src/Ambev.DeveloperEvaluation.WebApi
```

5. Execute a API:  
```
dotnet run --project ./src/Ambev.DeveloperEvaluation.WebApi
```
Acesse em http://localhost:5119

6. Use o Swagger para testar:  
Abra no navegador: http://localhost:5119/swagger

---

**Comandos úteis:**  
- Criar migration:  
```
dotnet ef migrations add NomeDaMigration --project ./src/Ambev.DeveloperEvaluation.ORM --startup-project ./src/Ambev.DeveloperEvaluation.WebApi
```
- Remover migration:  
```
dotnet ef migrations remove --project ./src/Ambev.DeveloperEvaluation.ORM --startup-project ./src/Ambev.DeveloperEvaluation.WebApi
```
- Restaurar pacotes:  
```
dotnet restore
```
- Build:  
```
dotnet build
```

---

**Observações:**  
- Ajuste a connection string conforme seu ambiente.  
- Garanta que o banco esteja rodando antes da API.  
- Para rodar banco via Docker, use o comando do passo 3.  
- Utilize o Swagger para explorar os endpoints.

---

Qualquer dúvida, abra uma issue no repo.

Boa sorte! 🚀
