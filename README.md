# Character Manager API
  
## Descrição

API desenvolvida para gerenciar personagens e batalhas em um jogo de RPG. Esta API permite criar personagens, listar personagens, obter detalhes de um personagem específico, iniciar uma batalha entre dois personagens e obter o log da batalha.

## Pré-requisitos

* .NET 6
* IDE (Recomendado: Visual Studio ou Visual Studio Code)

## Como executar

1. Clone o repositório para sua máquina local.
2. Abra a solução no Visual Studio ou Visual Studio Code.
3. Execute o projeto.

## Endpoints

### Personagem

* <b>Listar todos os personagens: </b> ```GET /api/personagens```
* <b>Obter detalhes de um personagem específico:</b> ```GET /api/personagem/{id}```
* <b>Criar um novo personagem:</b> ```POST /api/personagem```
* <b>Obter status de um personagem:</b> ```GET /api/personagem/{id}/status```
* <b>Listar profissões disponíveis:</b> ```GET /api/personagem/profissoes```

### Batalha

* <b>Iniciar uma batalha entre dois personagens:</b> ```POST /api/batalha/iniciar```

## Como usar

1. __Criar um personagem:__
* Antes de criar um personagem, obtenha a lista de profissões disponíveis usando o endpoint ```GET /api/personagem/profissoes```.
* Use a profissão obtida na lista para criar um personagem.
* Exemplo: <b>POST /api/personagem com corpo da requisição:</b>

```
{
  "nome": "Aragorn",
  "profissao": "Guerreiro"
}
```

2. __Listar personagens criados:__
* Use o endpoint ```GET /api/personagem``` para obter a lista de personagens criados.
* Anote os IDs dos personagens que deseja usar na batalha.
3. __Iniciar uma batalha:__
* Use o endpoint ```POST /api/batalha/```iniciar com corpo da requisição:

```
{
  "personagem1Id": "ID_DO_PERSONAGEM_1",
  "personagem2Id": "ID_DO_PERSONAGEM_2"
}
```

## Banco de Dados

A API utiliza um banco de dados In-Memory, o que significa que os dados serão perdidos assim que a aplicação for encerrada.