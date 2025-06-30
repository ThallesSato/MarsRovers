# Mars Rovers - Sistema de Controle de Sondas

Sistema de controle de sondas, simulando movimentação em um planalto.
Cada sonda executa comandos sequenciais, respeitando limites do terreno e evitando colisões.

## Como rodar o projeto

- Baixe o SDK do .net (8.0 ou superior)
- Clone ou baixe o projeto.
- Em um cmd na raiz do projeto:
- Insira o comando "dotnet restore" para baixar as dependências
- Insira o comando "dotnet build" para compilar o projeto
- Insira o comando "dotnet run --project .\MarsRovers.Console\MarsRovers.Console.csproj" para rodar o projeto
- Altere o arquivo input.txt na raiz do projeto para mudar a entrada programa

## Justificativas Técnicas

- Escolhi um ConsoleApp com entrada via arquivo de texto, pois não há necessidade de implementação de concorrência e todas as sondas devem seguir a ordem de processamento, é uma implementação simples.

- Para validação dos limites ou conflito de posição, eu escolhi ignorar o movimento e registrar uma mensagem no console simulando log, e continuar com processamento se possível.

- Para movimento ou direção não existente, escolhi lançar uma exceção, interromper o funcionamento e registrar a mensagem no console simulando log.


## Design Patterns:

- Utilizei o command pattern para os comandos das sondas, permitindo que seja expandida a quantidade de comandos sem ter que alterar as outras classes, seguindo o princípio OCP; 

- Utilizei também o factory pattern em conjunto, para converter para comandos o texto inserido, permitindo também a prática do OCP; 

- As classes estão separadas e com responsabilidade única seguindo o SRP.


## Debugging

Fiz o projeto usando o VSCode (geralmente uso Rider ou VS), para configurar apenas baixei o sdk, e as extensões de C# (C#, C# dev tools, IntelliCode for C# Dev Kit). Não precisei fazer mais alterações para o debug funcionar.
Devido a baixa complexidade do teste, não foi necessário usar ferramentas de debug avançado, como breakpoints condicionais. Apenas breakpoint e inspeção de variável foi suficiente.


## Pipeline CI

O pipeline foi configurado na seguinte estrutura: Nome do workflow -> Gatilhos de ativação -> Ações da pipeline.
- Gatilhos de ativação: defini que deve ser acionado sempre que um push na 'main' for feito ou manualmente via github actions;
- Ações da pipeline: defini que deve ser feito o restore, build, testes e commit do resultado. O build e testes geram um arquivo test_results/README.md que após ser gerado é feito um commit para ver os resultados inspecionando esse arquivo na pasta.

## I.A

Utilizei o ChatGpt e o Copilot, utilizado principalmente para aumentar produtividade, refatoração, melhora de performance do código e acelerar na resolução de erros.