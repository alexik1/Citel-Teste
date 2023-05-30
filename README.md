# Citel-Teste

Para iniciar, em Citel_Teste_Api/appettings.json, inserir uma connectionString para um MySQL como CitelDbContext.
Após, rodar ```add-migration``` e ```update-database``` via Citel_Teste_Infrastructure.

Via Visual Studio 2022 ou afins, haverão os perfis Web-IISEx (levará ao website em si), e o Swagger-IISEx.

Referente aos objetos, foram criados conforme deduzido o mínimo adequado para esta apresentação, incluindo relações entre estes.

Usado .NET 7.0 e Bootstrap mais atual para tal.
Usada arquitetura em camadas para melhor organização do código (API, Entity, Core e Infrastructure).

Desejável acrescentar:
-Testes Unitários
-Classes de Validação
-Classes de Exceções
-Disponibilidade de todas as funções da API no Front-End
-Sistema de Login
-Camada de Segurança (incluindo vault para parâmetros seguros)

