# CalcAudit System

![.NET 9](https://img.shields.io/badge/.NET%209-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Blazor](https://img.shields.io/badge/Blazor-512BD4?style=for-the-badge&logo=blazor&logoColor=white)
![Docker](https://img.shields.io/badge/Docker-2496ED?style=for-the-badge&logo=docker&logoColor=white)
![Azure](https://img.shields.io/badge/Azure-0078D4?style=for-the-badge&logo=microsoftazure&logoColor=white)

Uma aplicação de Calculadora moderna e containerizada, desenvolvida com **.NET 9 Blazor Web App**. O sistema conta com histórico de auditoria persistente, interface noturna e infraestrutura otimizada para nuvem com Docker e Azure.

---

## 🔗 Demo Online (Azure)

🚀 **Aplicação rodando em Produção:**
### [👉 Clique para acessar o CalcAudit (Azure Container Instances)](http://pekus-app-vitor.eastus.azurecontainer.io:8080)

*(Nota: Ambiente de demonstração via HTTP na porta 8080)*
> ⚠️ **Nota para acesso via Mobile:**
> Alguns navegadores móveis (Chrome/Safari) podem forçar automaticamente o redirecionamento para **HTTPS**.
> Como este é um ambiente de desenvolvimento (Azure Container Instances), ele roda sobre **HTTP** puro.
> **Se a página não carregar:** Verifique a barra de endereço e remova o "s" (garanta que está acessando `http://...`).
---

## ✨ Funcionalidades

- **Cálculos Precisos:** Operações aritméticas fundamentais (+, -, *, /, %) com tratamento de decimais.
- **Auditoria Completa:** Histórico detalhado de cada operação (ID, Data, Operação e Resultado).
- **Interface Moderna:** Design responsivo, focado em UX, com tema Dark e feedback visual (notificações flutuantes).
- **Segurança:** Integração protegida via API Key para operações de escrita no banco.
- **Arquitetura:** Separação de responsabilidades (Front/Back) com injeção de dependência.

---

## 🛠️ Tecnologias

- **Framework:** .NET 9 (Blazor Web App - Interactive Server)
- **Containerização:** Docker (Multi-stage build)
- **Cloud:** Azure Container Registry (ACR) & Azure Container Instances (ACI)
- **Frontend:** Bootstrap 5 & CSS 3
---

## 🐳 Como Rodar com Docker

Para rodar a aplicação localmente utilizando containers:

**1. Construir a imagem:**
```
docker build -t calcaudit-app .
```
**2. Executar o container: (Substitua SUA_CHAVE_AQUI pela sua API Key configurada ou use a padrão de dev)**
```
docker run -d -p 8080:8080 \
  -e "ApiSettings__ApiKey=sua_api_key_aqui" \


  --name calcaudit-app calcaudit-ap
```
***3. Acessar: Abra seu navegador em: http://localhost:8080**

-----
## ☁️ Detalhes do Deploy (Azure)

O deploy da aplicação foi realizado seguindo uma arquitetura moderna baseada em containers na nuvem da Microsoft:
- **Imagem Docker:** A aplicação foi empacotada em uma imagem Linux otimizada (Multi-stage build).
- **Registro (ACR):** A imagem foi enviada e versionada em um repositório privado no **Azure Container Registry**.
- **Execução (ACI):** O ambiente de produção roda sobre o **Azure Container Instances** (Serverless), onde o container foi provisionado com injeção segura de variáveis de ambiente (API Key) e exposição pública na porta 8080.

-----
## 👤 Autor

**Vitor Gomes Martins**

- **LinkedIn:** [Vitor Gomes](https://www.linkedin.com/in/vitor-gomes-martins/)
- **GitHub:** [vitor4818](https://github.com/vitor4818)
