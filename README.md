# Product Case - CRUD de Produtos com .NET, ASP.NET MVC e Entity Framework

Este projeto consiste em uma aplicação CRUD (Create, Read, Update, Delete) para gerenciamento de produtos, desenvolvida em **.NET**, **ASP.NET MVC** e **Entity Framework**. A solução inclui uma **API** para operações backend e uma aplicação **MVC** para a interface frontend.

## 📥 Configuração do Projeto

### 1. Clone o Repositório
```bash
git clone https://github.com/GustavoSelhorstMarconi/Product-Case.git
cd Product-Case
```

### 2. Configure a String de Conexão do Banco de Dados
Abra o arquivo appsettings.json no projeto da API (geralmente em src/ProductApi).

Localize a seção ConnectionStrings e insira a string de conexão do seu SQL Server:
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=SEU_SERVIDOR;Database=NOME_DO_BANCO;User Id=SEU_USUARIO;Password=SUA_SENHA;TrustServerCertificate=True;"
  }
}
Substitua SEU_SERVIDOR, NOME_DO_BANCO, SEU_USUARIO e SUA_SENHA pelos dados do seu ambiente.

### 3. Execute as Migrations

Abra o terminal na pasta do projeto da API (ou onde estão as migrations) e execute:

```bash
dotnet ef database update
```

OU no Visual Studio:

Abra o Package Manager Console.

Selecione o projeto de infraestrutura (onde estão as migrations).

```bash
Update-Database
```

### 4. Configure o Projeto de Inicialização
No Visual Studio:

Clique com o botão direito na solução > Properties.

Em Common Properties > Startup Project.

Defina a API.

Na outra solução só há um projeto.

Agora é só executar a aplicação.
