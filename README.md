API de Gerenciamento de Personagens e Batalhas
Uma API RESTful para criar, gerenciar personagens e realizar batalhas entre eles.
________________________________________
Índice
•	Pré-requisitos
•	Instalação e Configuração
•	Endpoints
•	Personagem
•	Batalha
•	Exemplos de Uso
•	Testes
•	Contribuição
•	Licença
•	Contato
________________________________________
Pré-requisitos
•	.NET 6
•	Banco de dados In-Memory
________________________________________
Instalação e Configuração
1.	Clone o repositório:

1. 
```bash
git clone https://github.com/seu_usuario/nome_do_repositorio.git
```

2.	Navegue até a pasta do projeto e instale as dependências:

1. ```bash
cd pasta_do_projeto dotnet restore 
```

3.	Execute a API:

```bash
dotnet
```


________________________________________

__Endpoints__

__Personagem__

__•	Listar Todos os Personagens__
	•	__Método:__ GET
	•	__Endpoint:__ /api/personagem
__•	Obter Detalhes de um Personagem__
	•	__Método:__ GET
	•	__Endpoint:__ /api/personagem/{id}
