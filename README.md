<h1>**Character Manager API**</h1>
  
<h3>**Descrição**</h3>

API desenvolvida para gerenciar personagens e batalhas em um jogo de RPG. Esta API permite criar personagens, listar personagens, obter detalhes de um personagem específico, iniciar uma batalha entre dois personagens e obter o log da batalha.

<h3><**Pré-requisitos**/h3>

•	.NET 6
•	**IDE (Recomendado:** Visual Studio ou Visual Studio Code)


<h3>**Como executar**</h3>

1.	Clone o repositório para sua máquina local.
2.	Abra a solução no Visual Studio ou Visual Studio Code.
3.	Execute o projeto.

________________________________________

<h3>**Endpoints**</h3>

<h5>**Personagem**</h5>

•	**Listar todos os personagens: **GET /api/personagem
•	**Obter detalhes de um personagem específico:** GET /api/personagem/{id}
•	**Criar um novo personagem:** POST /api/personagem
•	**Obter status de um personagem:** GET /api/personagem/{id}/status
•	**Listar profissões disponíveis:** GET /api/personagem/profissoes

<h5>**Batalha**</h5>

•	**Iniciar uma batalha entre dois personagens:** POST /api/batalha/iniciar

________________________________________

<h3>**Como usar**</h3>

**1. Criar um personagem:**
•	Antes de criar um personagem, obtenha a lista de profissões disponíveis usando o endpoint ````GET /api/personagem/profissoes```.
•	Use a profissão obtida na lista para criar um personagem.
•	Exemplo: **POST /api/personagem com corpo da requisição:**

```
{
  "nome": "Aragorn",
  "profissao": "Guerreiro"
}
```

**2. Listar personagens criados:**
•	Use o endpoint ```GET /api/personagem``` para obter a lista de personagens criados.
•	Anote os IDs dos personagens que deseja usar na batalha.
**3. Iniciar uma batalha:**
•	Use o endpoint ```POST /api/batalha/```iniciar com corpo da requisição:

```
{
  "personagem1Id": "ID_DO_PERSONAGEM_1",
  "personagem2Id": "ID_DO_PERSONAGEM_2"
}
```

________________________________________

<h3>**Banco de Dados**</h3>

A API utiliza um banco de dados In-Memory, o que significa que os dados serão perdidos assim que a aplicação for encerrada.




