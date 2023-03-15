# REST API Fandom-Star-Wars

## Sobre o Projeto 
- Esta Aplicação consiste de 6 projetos (Domain, Application, Infra.Data, Infra.Data.IoC, API, Tests) que compõem uma API REST Sobre o Universo de Star Wars, onde temos um CRUD onde pode-se criar e editar personages e filmes da franquia. Para popular inicialmente o banco de dados, foi consumida a API https://swapi.dev que contém diversas informações sobre a franquia. Esta é uma aplicação onde foi possível realizar uma ampla cobertura de testes, onde temos tanto o domínio quanto a camada de aplicação coberto por testes unitários.

## Ferramentas e padrões de desenvolvimento utilizados
- C#
- .NET
- Dotnet 6
- Versionamento de Código com Git e Github
- Padronização de Commits com Commitizen
- Testes Unitários 
- XUnit Test
- FakeRepository
- Swagger
- AutoMapper 
- EntityFrameWork
- Microsoft.AspNetCore.Identity.EntityFrameworkCore
- PostgreSQL
- Abordagem Code First
- Arquitetura Clean Code
- Princípios SOLID
- Refit 
- DTO's
- CQRS (Obs.: Neste projeto o CQRS foi utilizado apenas para fins didáticos, pois o volume de dados é baixo, em um cenário ideal com um alto volume de dados, poderíamos utilizar bancos diferentes para escrita e consulta, conseguindo assim obter uma melhor performance deste padrão)
- Notification Pattern 
- Façade Pattern
- FluentValidation
- MediatR


## Conhecendo a estrutura da Aplicação

### Camada de Domínio, FandomStarWars.Domain
- Este projeto consiste no Domínio da aplicação, aqui nós temos um projeto com C# puro e sem dependência externa aos outros projetos, aqui encontram-se as entidades e os contratos dos repositórios. É importante ressaltar que ao fazermos o domínio depender de abstrações dos repositórios e não de sua implementação em si, criamos um baixo acoplamento e isso facilita a manutenção do código.

### Camada de Aplicação, FandomStarWars.Application
Na Camada de Application nós tesmos a implementação do CQRS, implementação dos serviços que serão utilizados pela camada API e o serviço que consome a API Externa swapi.dev, também temos a definição dos DTO's e de seus respectivos mapeamentos, que são utilizados para mapearmos uma entidade em um DTO e vice versa, com isso impedimos que as camadas que consumirão nossos serviços conheçam as entidades de nosso domínio, estas conhecerão apenas as informações fornecidas nos DTO's.

### Camada de Infraestrutura de Dados, FandomStarWars.Infra.Data
- Nesta camada nós temos a configuração do nosso contexto, as configurações de como nossas entidades serão representadas no banco, configuração do Identity, Migrations e Implementação dos Repositórios cujos cantratos são as interfaces que se encontram na camada de domínio. Vale ressaltar que este proojeto utiliza a abordagem code first (Código Primeiro), ou seja, primeiro nós modelamos nosso domínio e depois pensamos no banco de dados, e com isso, além de ser mais rápido e produtivo, o banco se torna apenas um detalhe, ainda mais quando se utiliza do Entity Framework como neste projeto, isto faz com que seja extremamente fácil a criação e modificação do banco atravéz da utilização de Migrations, e também torna muito mais fácil a troca de bancos de dados caso seja necessário.

### Camada Infra IoC, FandomStarWars.Infra.IoC
- Esta camada nós utilizamos para configurar e resolver todas as dependências do projeto.

### Camada de Testes, FandomStarWars.Tests
- Esta é a camada onde realizamos os testes unitários, como já foi dito anteriormente, esta aplicação é totalmente testável, desde seu domínio até os Commands, Querys e Handlers do CQRS que são responsáveis pelo entrada e saída de informações. 

### Camada da API, FandomStarWars.API
- Está é a camada responsável por estabelecer os Endpoints da aplicação e a utilização de nossos serviços nos seus Controllers.



## Responsável pelo Projeto: Isaque Diniz da Silva
#### Redes Sociais
[Linkedin](https://www.linkedin.com/in/isaque-diniz-da-silva-a0773459/)
</br>
[GitHub](https://github.com/isaque14)