# Sistema Corporativo 
# Sistema Corporativo

Sistema corporativo desenvolvido em **C# .NET 8**, com arquitetura em camadas,
voltado para gestão de colaboradores, cargos, permissões e processos de RH.

## Tecnologias
- .NET 8
- ASP.NET Core Web API
- Arquitetura em Camadas
- Orientação a Objetos

## Estrutura
API: endpoints e autenticação
Aplicação: regras de negócio
Domínio: entidades e contratos
Infraestrutura: persistência e serviços externos


Atualização no sistema

projeto estruturados em camadas com mencionado desde o inicio o que apliquei:

Na camada de dominio --> Entidades, Regras de negocio encapsuladas trazendo boa pratica com orientação a objeto, Enumas e contratos com  interfaces.



Aplicaçao --> Dtos com entrada e saidas, Serviçoes de aplicação, e orquestrando os casos em usos em implementação ainda melhorias mais a frente.


Infraestrutura --> Entidades que irei implemetar agora com Framework Core quando falo agora como documentação de proximo passo a seguir,  implementação com banco de dados inciando.

API --> Iniciei criando a pasta de Controller para fazer uma injeçao de dependencias e endpoint Rest.

A ideia que estou colocando nesse sistema e para prática com o C# e a ideia em si do projeto e qye um colaborador ele faça login por meio de CPF ou email,  senha e salario padrão no inicio recuperação de senha por email, visualizaer ali seu holerite,
envio de atestados, pode realizar ate alguns questionamentos com valores indevidos no pagamento,


Irei implementar ne ja comecei no contexto tambem a parte de gestao alyteração de cargosm controle de permissao ativar e desativar colaborador 


Tambem pensando logico como primordial como boa prática em desenvolvimento nao me esquencendo da LGPD irei inicialmente pensamndo em algo mais simples autenticacao baseada por identidade, perfis e permissoes por cargos, senhas criptografadas , mais irei depois tentar desenvolver por mais camadas de segunranca de autenticacao nao deixar somente ali por uma senha ou email cpf implementar um sistema de reconheciemnto facial, verificação de duaas etapas utilizando authenticator masi para frente.

atualizar