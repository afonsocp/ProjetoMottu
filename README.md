# Moto Patio API

API para gerenciamento de motos em pátios, desenvolvida com ASP.NET Core e Entity Framework Core.

## Repositório GitHub
- https://github.com/afonsocp/ProjetoMottu.NET

## Participantes
- Afonso Correia Pereira - RM557863
- Adel Mouhaidly - RM557705 
- Tiago Augusto Desiderato - RM558485 

## Descrição do Projeto

Sistema desenvolvido para gerenciar o controle de motos em pátios, permitindo:
- Cadastro e controle de usuários
- Gerenciamento de localizações nos pátios
- Controle de motos e suas localizações
- Agendamento de reservas
- Registro de manutenções

## Tecnologias Utilizadas

- ASP.NET Core 7.0
- Entity Framework Core
- Oracle Database
- Swagger/OpenAPI para documentação
- Sistema de migrations para controle do banco de dados

## Instalação e Configuração

1. Pré-requisitos:
   - .NET 7.0 SDK
   - Oracle Database
   - Visual Studio 2022 ou VS Code

2. Clone o repositório:
bash

git clone https://github.com/afonsocp/ProjetoMottu.NET
cd Sprint-net

3. Configure a string de conexão no arquivo appsettings.json:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=oracle.fiap.com.br:1521/ORCL;User Id=rm557863;Password=091105;"
  }
}
```

4. Execução das Migrations

```bash
dotnet ef database update
```

5. Execução do Projeto

```bash
dotnet run
```

---

## 🧱 Estrutura do Projeto

O projeto está organizado nas seguintes camadas:

- `Models`: Entidades do domínio  
- `Controllers`: Endpoints da API  
- `Context`: Configuração do Entity Framework  
- `Migrations`: Controle de versão do banco de dados

---

## 🌐 Endpoints da API

### Usuários

| Método | Rota                         | Descrição                    |
|--------|------------------------------|------------------------------|
| GET    | /api/Usuario                 | Lista todos os usuários      |
| GET    | /api/Usuario/{id}            | Busca usuário por ID         |
| GET    | /api/Usuario?cargo={cargo}   | Filtra usuários por cargo    |
| POST   | /api/Usuario                 | Cria novo usuário            |
| PUT    | /api/Usuario/{id}            | Atualiza usuário             |
| DELETE | /api/Usuario/{id}            | Remove usuário               |

### Localizações

| Método | Rota                            | Descrição                    |
|--------|---------------------------------|------------------------------|
| GET    | /api/Localizacao                | Lista todas as localizações |
| GET    | /api/Localizacao/{id}           | Busca localização por ID     |
| POST   | /api/Localizacao                | Cria nova localização        |
| PUT    | /api/Localizacao/{id}           | Atualiza localização         |
| DELETE | /api/Localizacao/{id}           | Remove localização           |

### Motos

| Método | Rota                | Descrição             |
|--------|---------------------|------------------------|
| GET    | /api/Motos          | Lista todas as motos  |
| GET    | /api/Motos/{id}     | Busca moto por ID     |
| POST   | /api/Motos          | Cadastra nova moto    |
| PUT    | /api/Motos/{id}     | Atualiza moto         |
| DELETE | /api/Motos/{id}     | Remove moto           |

### Manutenções

| Método | Rota                        | Descrição                  |
|--------|-----------------------------|-----------------------------|
| GET    | /api/Manutencao             | Lista todas as manutenções |
| GET    | /api/Manutencao/{id}        | Busca manutenção por ID     |
| POST   | /api/Manutencao             | Registra nova manutenção    |
| PUT    | /api/Manutencao/{id}        | Atualiza manutenção         |
| DELETE | /api/Manutencao/{id}        | Remove manutenção           |

### Reservas

| Método | Rota                  | Descrição              |
|--------|-----------------------|-------------------------|
| GET    | /api/Reserva          | Lista todas as reservas|
| GET    | /api/Reserva/{id}     | Busca reserva por ID   |
| POST   | /api/Reserva          | Cria nova reserva      |
| PUT    | /api/Reserva/{id}     | Atualiza reserva       |
| DELETE | /api/Reserva/{id}     | Remove reserva         |

---

## 📦 Exemplos de Requisições

### Criar Usuário

```json
POST /api/Usuario
{
  "nome": "João Silva",
  "email": "joao.silva@exemplo.com",
  "senha": "senha123"
}
```

### Criar Localização

```json
POST /api/Localizacao
{
  "endereco": "Avenida Paulista, 1000",
  "cep": "01310-100",
  "cidade": "São Paulo",
  "estado": "SP"
}
```

### Criar Moto

```json
POST /api/Motos
{
  "placa": "ABC1234",
  "modelo": "Honda CB 500",
  "ano": 2023,
  "status": "Disponível",
  "ID_Localizacao": 1
}
```

### Criar Manutenção

```json
POST /api/Manutencao
{
  "data": "2024-03-15",
  "descricao": "Troca de óleo",
  "custo": 150.00,
  "ID_Moto": 1
}
```

### Criar Reserva

```json
POST /api/Reserva
{
  "data_Reserva": "2024-03-20",
  "data_Devolucao": "2024-03-25",
  "ID_Usuario": 1,
  "ID_Moto": 1
}
```

---

## 🔁 Códigos de Retorno

- 200 (OK): Requisição bem-sucedida  
- 201 (Created): Recurso criado com sucesso  
- 204 (No Content): Requisição bem-sucedida sem conteúdo  
- 400 (Bad Request): Erro na requisição  
- 404 (Not Found): Recurso não encontrado

---

## 📘 Documentação Adicional

A documentação completa da API está disponível através do Swagger UI, acessível via:  
[http://localhost:5000](http://localhost:5000)

---
