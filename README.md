# 🌧️ AlertaChuva.API

Sistema de monitoramento e alerta para enchentes, voltado para comunidades em áreas de risco. A aplicação permite o cadastro de sensores, registro de leituras de nível de água e emissão automática de alertas via API e interface web (Razor Pages).

---

## 📌 Objetivo

Desenvolver uma solução integrada e escalável capaz de:

- Monitorar níveis de água em tempo real
- Gerar alertas automáticos em casos de risco
- Oferecer interface de visualização de dados
- Integrar tecnologias como IoT, API REST, banco de dados relacional e Razor Pages

---

## 🛠️ Tecnologias Utilizadas

| Camada         | Tecnologias                                 |
| -------------- | ------------------------------------------- |
| Backend (API)  | .NET 9, ASP.NET Core, Razor Pages           |
| Banco de Dados | Oracle 19c (via Oracle.EntityFrameworkCore) |
| ORM            | Entity Framework Core                       |
| Documentação   | Swagger (Swashbuckle.AspNetCore)            |
| Interface Web  | Razor Pages + TagHelpers                    |
| Linguagens     | C#, SQL                                     |
| Deploy local   | CLI + EF Core Migrations                    |

---

## 📦 Estrutura do Projeto

```bash
AlertaChuva.API/
├── Controllers/
├── Data/
├── DTOs/
├── Models/
├── Pages/
│   ├── Alertas/
│   ├── Leituras/
│   ├── Sensores/
│   └── Usuarios/
├── Services/
│   ├── Interfaces/
│   └── Implementacoes/
├── Program.cs
├── appsettings.json
└── README.md
```

---

## 🔧 Configuração do Ambiente

### Requisitos

- .NET SDK 9.0+
- Banco de dados Oracle
- Ferramenta CLI do EF Core
- Visual Studio Code ou Visual Studio 2022+

### Instalação de Pacotes

```bash
dotnet restore
dotnet build
dotnet ef database update
dotnet run
```

---

## 🧪 Funcionalidades da API

### 🔹 Entidades

- **Usuário**: cadastro de moradores e administradores
- **Sensor**: vinculado ao usuário, registra localização e nível crítico
- **Leitura**: associada a um sensor, registra nível de água
- **Alerta**: criado automaticamente quando nível ultrapassa o limite

### 🔹 Endpoints REST

| Método | Rota                    | Descrição                        |
| ------ | ----------------------- | -------------------------------- |
| GET    | /api/usuario            | Listar usuários                  |
| POST   | /api/sensor             | Cadastrar novo sensor            |
| POST   | /api/leitura            | Registrar leitura e gerar alerta |
| PUT    | /api/alerta/{id}/status | Resolver alerta                  |
| GET    | /api/alerta             | Listar todos os alertas          |

---

## 🖥️ Razor Pages

As seguintes interfaces web estão disponíveis:

- `/Alertas` – lista de alertas gerados
- `/Sensores` – lista de sensores cadastrados
- `/Leituras` – histórico de leituras
- `/Usuarios` – lista de usuários do sistema

---

## 📊 Swagger

Acesse:  
📎 [`https://localhost:{PORT}/swagger`](https://localhost:{PORT}/swagger)

Documentação gerada automaticamente com todos os endpoints.

---

## 🔒 Segurança

> Este projeto utiliza validação básica via DTOs e separação clara entre Model e camada de API. O uso de autenticação JWT pode ser adicionado como melhoria futura.

---

## 📈 Melhorias Futuras

- Integração com sensores reais via MQTT
- Notificações em tempo real
- Login e autenticação com JWT
- Módulo de evacuação e alerta por SMS/app

---

## 👨‍💻 Desenvolvido por

- **Nome**: Gabriel Teodoro Gonçalves Rosa, Luka Ura Shibuya, Eduardo Ribeiro Giovannini
- **RM**: RM555962, RM558123, RM555030
- **Turma**: 2TDSF - Global Solution 2025/1
- **Instituição**: FIAP

## Links

- [Demonstração da Solução](link_da_demonstracao)
- [Pitch da Solução](link_do_pitch)
