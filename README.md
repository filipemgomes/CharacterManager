<h1><b>Character Manager API</b></h1>
  
<h3><b>Descrição</b>h3>

<p>API desenvolvida para gerenciar personagens e batalhas em um jogo de RPG. Esta API permite criar personagens, listar personagens, obter detalhes de um personagem específico, iniciar uma batalha entre dois personagens e obter o log da batalha.</p

<h3><b>Pré-requisitos</b></h3>

<p>
•	.NET 6
•	<b>IDE (Recomendado:</b> Visual Studio ou Visual Studio Code)
</p>


<h3><b>Como executar</b>h3>

1.	Clone o repositório para sua máquina local.
2.	Abra a solução no Visual Studio ou Visual Studio Code.
3.	Execute o projeto.

________________________________________

<h3><b>Endpoints</b></h3>

<h5><b>Personagem</b></h5>

•	<b>Listar todos os personagens: </b> ```GET /api/personagem```
•	<b>Obter detalhes de um personagem específico:</b> ```GET /api/personagem/{id}```
•	<b>Criar um novo personagem:</b> ```POST /api/personagem```
•	<b>Obter status de um personagem:</b> ```GET /api/personagem/{id}/status```
•	<b>Listar profissões disponíveis:</b> ```GET /api/personagem/profissoes```

<h5><b>Batalha</b></h5>

•	<b>Iniciar uma batalha entre dois personagens:</b> ```POST /api/batalha/iniciar```

________________________________________

<h3><b>Como usar**</</b>h3>

<b>1. Criar um personagem:</b>
•	Antes de criar um personagem, obtenha a lista de profissões disponíveis usando o endpoint ````GET /api/personagem/profissoes```.
•	Use a profissão obtida na lista para criar um personagem.
•	Exemplo: <b>POST /api/personagem com corpo da requisição:</b>

```
{
  "nome": "Aragorn",
  "profissao": "Guerreiro"
}
```

<b>2. Listar personagens criados:</b>
•	Use o endpoint ```GET /api/personagem``` para obter a lista de personagens criados.
•	Anote os IDs dos personagens que deseja usar na batalha.
<b>3. Iniciar uma batalha:</b>
•	Use o endpoint ```POST /api/batalha/```iniciar com corpo da requisição:

```
{
  "personagem1Id": "ID_DO_PERSONAGEM_1",
  "personagem2Id": "ID_DO_PERSONAGEM_2"
}
```

________________________________________

<h3><b>Banco de Dados</b></h3>

A API utiliza um banco de dados In-Memory, o que significa que os dados serão perdidos assim que a aplicação for encerrada.




