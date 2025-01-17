Projeto em Camadas
-"Contracts" onde ficam os contratos de todas as outras camadas de suporte do sistema, servindo de assinaturas usando interfaces. Trazendo injeção de dependência e melhorando a independencia/menor acoplamento do sistema.
-"Repositories" onde ficam todas as chamadas de repositorios do projeto, incluindo e extraindo os arquivos JSON, alimentando a camada principal de web Service - API
-"Models" onde ficam as entidades do projetos, dividos em papeis de atuação, trazendo o Single Responsiblity Principle
-"Managers" onde se encontra a camada de negócios, fechando a arquitetura DDD
- Na camada API, temos ServiceExtensions para separar as assinaturas de injeção de dependência 
- Camada de teste, utilizando XUnit, contemplando as principais circunstancias das funcionalidades do projeto, partindo dos conceitos TDD