ORIENTAÇÕES PARA USAR A API DE FILMES: 

GET:
https://localhost:7106/Filme: Retorna todos os Filmes Da Lista
https://localhost:7106/Filme/{id}: Retorna o filme com o Id especifico
https://localhost:7106/Filme?skip={quantidade_para_pular}&take={quantidade_para_apresentar}
	
POST:
https://localhost:7106/Filme/: Adiciona um Filme no Banco
Exemplo:
 [
 {
 "titulo": "Pânico", 
 "genero": "Terror",
 "duracao": 85
 }
 ]


PACH:
https://localhost:7106/Filme/{id}: Editar Valor Do Campo Isoladamente
Exempplo:
[
{
    "op": "replace",
    "path": "/titulo",
    "value": "Pânico"
}
]
