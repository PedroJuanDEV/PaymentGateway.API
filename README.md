# Payment Gateway API

Um microsserviço RESTful robusto desenvolvido em .NET para processamento de pagamentos. Este projeto foi arquitetado com foco em segurança, integridade de dados transacionais e boas práticas de engenharia de software.

## Visão Geral do Sistema

A API atua como o motor de validação e registro de transações financeiras simuladas. O sistema gerencia o cadastro de clientes e o processamento de pagamentos, garantindo que operações críticas não sejam duplicadas em cenários de instabilidade de rede.

### Capturas de Tela

<img width="1913" height="951" alt="image" src="https://github.com/user-attachments/assets/5b49a761-bb12-4cbf-98e0-a02b76586cd9" />
*Interface de documentação e testes das rotas via Swagger UI.*

<img width="1405" height="432" alt="image" src="https://github.com/user-attachments/assets/00b129fe-a6c1-4cdd-801e-a0f905128bca" />
*Estrutura relacional do banco de dados visualizada através do DBeaver.*

## Stack Tecnológico e Ferramentas

* **Framework:** .NET 8 / 9 (C#)
* **ORM:** Entity Framework Core (Code-First)
* **Banco de Dados:** SQL Server
* **Documentação:** Swagger / OpenAPI

## Arquitetura e Diferenciais Técnicos

* **Proteção de Idempotência:** Implementação de `IdempotencyKey` no fluxo de pagamento. O sistema previne a cobrança dupla no cartão do cliente caso a requisição seja reenviada devido a falhas de comunicação ou retentativas de interface.
* **Validações de Domínio:** Utilização de Data Annotations para garantir a integridade dos DTOs (Data Transfer Objects) na entrada dos controladores, incluindo validações de regras de negócio.
* **Injeção de Dependência:** Desacoplamento da camada de acesso a dados (`DbContext`) do ciclo de vida da aplicação.

## Soft Skills e Competências Aplicadas

O desenvolvimento deste projeto tem exigido a aplicação constante das seguintes habilidades:

* **Visão Sistêmica e Arquitetural:** Capacidade de planejar o ciclo completo do dado, desde a interação do usuário no aplicativo até a persistência segura no banco de dados relacional.
* **Resolução de Problemas (Problem Solving):** Antecipação de falhas de rede e implementação de soluções complexas (como a idempotência) para garantir a resiliência do software.
* **Adaptabilidade e Aprendizado Contínuo:** Transição ágil entre tecnologias de Back-end (C#/.NET) e a preparação para integração com ecossistemas de Front-end mobile.

## Status do Projeto e Próximos Passos

**Status Atual: Em Construção**

A estrutura principal do back-end está operacional e validada. No momento atual, o foco do desenvolvimento está na construção do Front-end:
* Desenvolvimento de um aplicativo mobile em React Native (Expo) utilizando TypeScript.
* Construção de uma interface de e-commerce de alto padrão visual baseada no conceito UI/UX de "Cápsulas".
* Integração das rotas de Matrícula de Clientes e Checkout (consumo da API via Axios).

## Como Executar Localmente

1. Clone este repositório:
   ```bash
   git clone [https://github.com/PedroJuanDEV/PaymentGateway.API.git](https://github.com/PedroJuanDEV/PaymentGateway.API.git)

2. Configure a string de conexão com o seu SQL Server no arquivo appsettings.json.

3. Abra o terminal na raiz do projeto e aplique as migrações para construir o esquema do banco:
``` bash
dotnet ef database update

4. Inicie o servidor
  ```bash
   dotnet run

5. Acesse a documentação local via navegador: https://localhost:<sua_porta>/swagger


