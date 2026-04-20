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


Apos rodar o Docker compose: dotnet ef database update


Lista de Filmes do Db:

[
  {"Titulo": "V de Vingança", "Genero": "Ficção", "Duracao": 132},
  {"Titulo": "O Poderoso Chefão", "Genero": "Crime", "Duracao": 175},
  {"Titulo": "Batman: O Cavaleiro das Trevas", "Genero": "Ação", "Duracao": 152},
  {"Titulo": "Pulp Fiction", "Genero": "Crime", "Duracao": 154},
  {"Titulo": "Forrest Gump: O Contador de Histórias", "Genero": "Drama", "Duracao": 142},
  {"Titulo": "A Origem", "Genero": "Ficção", "Duracao": 148},
  {"Titulo": "Clube da Luta", "Genero": "Drama", "Duracao": 139},
  {"Titulo": "Matrix", "Genero": "Ficção", "Duracao": 136},
  {"Titulo": "O Senhor dos Anéis: O Retorno do Rei", "Genero": "Fantasia", "Duracao": 201},
  {"Titulo": "Interestelar", "Genero": "Ficção", "Duracao": 169},
  {"Titulo": "Seven: Os Sete Crimes Capitais", "Genero": "Mistério", "Duracao": 127},
  {"Titulo": "Gladiador", "Genero": "Ação", "Duracao": 155},
  {"Titulo": "O Rei Leão", "Genero": "Animação", "Duracao": 88},
  {"Titulo": "Cidade de Deus", "Genero": "Crime", "Duracao": 130},
  {"Titulo": "O Silêncio dos Inocentes", "Genero": "Suspense", "Duracao": 118},
  {"Titulo": "O Resgate do Soldado Ryan", "Genero": "Guerra", "Duracao": 169},
  {"Titulo": "Coringa", "Genero": "Drama", "Duracao": 122},
  {"Titulo": "Parasita", "Genero": "Suspense", "Duracao": 132},
  {"Titulo": "A Lista de Schindler", "Genero": "História", "Duracao": 195},
  {"Titulo": "Django Livre", "Genero": "Western", "Duracao": 165},
  {"Titulo": "O Grande Hotel Budapeste", "Genero": "Comédia", "Duracao": 99},
  {"Titulo": "Bastardos Inglórios", "Genero": "Guerra", "Duracao": 153},
  {"Titulo": "Ilha do Medo", "Genero": "Suspense", "Duracao": 138},
  {"Titulo": "Whiplash: Em Busca da Perfeição", "Genero": "Drama", "Duracao": 106},
  {"Titulo": "O Lobo de Wall Street", "Genero": "Biografia", "Duracao": 180},
  {"Titulo": "Alien: O Oitavo Passageiro", "Genero": "Ficção", "Duracao": 117},
  {"Titulo": "Exterminador do Futuro 2", "Genero": "Ficção", "Duracao": 137},
  {"Titulo": "Jurassic Park", "Genero": "Aventura", "Duracao": 127},
  {"Titulo": "De Volta para o Futuro", "Genero": "Ficção", "Duracao": 116},
  {"Titulo": "Psicose", "Genero": "Terror", "Duracao": 109},
  {"Titulo": "O Iluminado", "Genero": "Terror", "Duracao": 146},
  {"Titulo": "Blade Runner 2049", "Genero": "Ficção", "Duracao": 164},
  {"Titulo": "Mad Max: Estrada da Fúria", "Genero": "Ação", "Duracao": 120},
  {"Titulo": "Cisne Negro", "Genero": "Drama", "Duracao": 108},
  {"Titulo": "Donnie Darko", "Genero": "Ficção", "Duracao": 113},
  {"Titulo": "Cidade dos Sonhos", "Genero": "Mistério", "Duracao": 147},
  {"Titulo": "Laranja Mecânica", "Genero": "Crime", "Duracao": 136},
  {"Titulo": "Taxi Driver", "Genero": "Crime", "Duracao": 114},
  {"Titulo": "Scarface", "Genero": "Crime", "Duracao": 170},
  {"Titulo": "O Profissional", "Genero": "Ação", "Duracao": 110},
  {"Titulo": "Seven Samurai", "Genero": "Ação", "Duracao": 207},
  {"Titulo": "A Viagem de Chihiro", "Genero": "Animação", "Duracao": 125},
  {"Titulo": "Princesa Mononoke", "Genero": "Animação", "Duracao": 134},
  {"Titulo": "Oldboy", "Genero": "Mistério", "Duracao": 120},
  {"Titulo": "O Labirinto do Fauno", "Genero": "Fantasia", "Duracao": 119},
  {"Titulo": "A Vida é Bela", "Genero": "Drama", "Duracao": 116},
  {"Titulo": "Cinema Paradiso", "Genero": "Drama", "Duracao": 155},
  {"Titulo": "Os Bons Companheiros", "Genero": "Crime", "Duracao": 146},
  {"Titulo": "Fogo Contra Fogo", "Genero": "Crime", "Duracao": 170},
  {"Titulo": "Minority Report", "Genero": "Ficção", "Duracao": 145},
  {"Titulo": "Looper: Assassinos do Futuro", "Genero": "Ficção", "Duracao": 119},
  {"Titulo": "Distrito 9", "Genero": "Ficção", "Duracao": 112},
  {"Titulo": "Elysium", "Genero": "Ficção", "Duracao": 109},
  {"Titulo": "Chappie", "Genero": "Ficção", "Duracao": 120},
  {"Titulo": "Prometheus", "Genero": "Ficção", "Duracao": 124},
  {"Titulo": "Perdido em Marte", "Genero": "Ficção", "Duracao": 144},
  {"Titulo": "Gravidade", "Genero": "Ficção", "Duracao": 91},
  {"Titulo": "Duna", "Genero": "Ficção", "Duracao": 155},
  {"Titulo": "Duna: Parte 2", "Genero": "Ficção", "Duracao": 166},
  {"Titulo": "Homem-Aranha: No Aranhaverso", "Genero": "Animação", "Duracao": 117},
  {"Titulo": "Toy Story", "Genero": "Animação", "Duracao": 81},
  {"Titulo": "Procurando Nemo", "Genero": "Animação", "Duracao": 100},
  {"Titulo": "Wall-E", "Genero": "Animação", "Duracao": 98},
  {"Titulo": "Up: Altas Aventuras", "Genero": "Animação", "Duracao": 96},
  {"Titulo": "Divertida Mente", "Genero": "Animação", "Duracao": 95},
  {"Titulo": "Coco", "Genero": "Animação", "Duracao": 105},
  {"Titulo": "Ratatouille", "Genero": "Animação", "Duracao": 111},
  {"Titulo": "Shrek", "Genero": "Animação", "Duracao": 90},
  {"Titulo": "Como Treinar o Seu Dragão", "Genero": "Animação", "Duracao": 98},
  {"Titulo": "Kung Fu Panda", "Genero": "Animação", "Duracao": 92},
  {"Titulo": "Megamente", "Genero": "Animação", "Duracao": 95},
  {"Titulo": "O Auto da Compadecida", "Genero": "Comédia", "Duracao": 104},
  {"Titulo": "Tropa de Elite", "Genero": "Ação", "Duracao": 115},
  {"Titulo": "Central do Brasil", "Genero": "Drama", "Duracao": 113},
  {"Titulo": "Bacurau", "Genero": "Suspense", "Duracao": 131},
  {"Titulo": "Aquarius", "Genero": "Drama", "Duracao": 146},
  {"Titulo": "O Homem do Futuro", "Genero": "Comédia", "Duracao": 105},
  {"Titulo": "Bingo: O Rei das Manhãs", "Genero": "Biografia", "Duracao": 113},
  {"Titulo": "Que Horas Ela Volta?", "Genero": "Drama", "Duracao": 112},
  {"Titulo": "Getúlio", "Genero": "História", "Duracao": 140},
  {"Titulo": "Carandiru", "Genero": "Drama", "Duracao": 145},
  {"Titulo": "Bicho de Sete Cabeças", "Genero": "Drama", "Duracao": 74},
  {"Titulo": "Abril Despedaçado", "Genero": "Drama", "Duracao": 105},
  {"Titulo": "Lisbela e o Prisioneiro", "Genero": "Romance", "Duracao": 105},
  {"Titulo": "Se Eu Fosse Você", "Genero": "Comédia", "Duracao": 105},
  {"Titulo": "Minha Mãe é uma Peça", "Genero": "Comédia", "Duracao": 85},
  {"Titulo": "O Palhaço", "Genero": "Comédia", "Duracao": 90},
  {"Titulo": "Hoje Eu Quero Voltar Sozinho", "Genero": "Romance", "Duracao": 96},
  {"Titulo": "Tatuagem", "Genero": "Drama", "Duracao": 110},
  {"Titulo": "O Animal Cordial", "Genero": "Suspense", "Duracao": 98},
  {"Titulo": "As Boas Maneiras", "Genero": "Terror", "Duracao": 135},
  {"Titulo": "A Vida Invisível", "Genero": "Drama", "Duracao": 139},
  {"Titulo": "Benzinho", "Genero": "Drama", "Duracao": 95},
  {"Titulo": "Divino Amor", "Genero": "Drama", "Duracao": 101},
  {"Titulo": "Corpo Elétrico", "Genero": "Drama", "Duracao": 94},
  {"Titulo": "Era Uma Vez Eu, Verônica", "Genero": "Drama", "Duracao": 91},
  {"Titulo": "Viajo Porque Preciso, Volto Porque Te Amo", "Genero": "Drama", "Duracao": 75},
  {"Titulo": "O Som ao Redor", "Genero": "Drama", "Duracao": 131},
  {"Titulo": "Tropa de Elite 2", "Genero": "Ação", "Duracao": 115},
  {"Titulo": "Chatô, o Rei do Brasil", "Genero": "Biografia", "Duracao": 106}
]
