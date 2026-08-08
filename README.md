# ApiIp

API REST em .NET 10 para consulta de geolocalização e informações de risco de um endereço IP, usando a [ipquery.io](https://ipquery.io) como provedor de dados.

## Como funciona

```
Controller (IpController) → Service (IpService) → Rest (ApiRest) → api.ipquery.io
                                    ↓         ↑
                          IpLogRepository   AutoMapper (Root → IpResponse)
                                    ↓
                              MySQL (LOGS.Ips)
```

1. `IpController` recebe a requisição HTTP e delega para `IpInterfaceService`.
2. `IpService` chama `IpInterfaceRest` para buscar os dados brutos e usa o AutoMapper para converter o modelo bruto (`Root`) no DTO de resposta (`IpResponse`).
3. `ApiRest` faz a chamada HTTP para `https://api.ipquery.io/{ip}` e desserializa o retorno.
4. `IpService` registra a consulta (sucesso ou erro) no MySQL via `IpInterfaceLogRepository`. Falha ao gravar não afeta a resposta ao cliente — só vai pro log da aplicação.

Toda resposta interna (sucesso ou erro) trafega dentro de `ResponseGenerico<T>`, que carrega o `HttpStatusCode`, os dados (`DadosRetorno`) ou o erro (`ErroRetorno`).

## Endpoint

### `GET /v1/Ip/{ip}`

Retorna dados de geolocalização, provedor e risco (VPN/Tor/proxy/datacenter) para o IP informado.

**Requisição de exemplo**

```
GET /v1/Ip/8.8.8.8
```

**Resposta 200 OK**

```json
{
  "provedor": "Google LLC",
  "pais": "United States",
  "siglaPais": "US",
  "cidade": "Mountain View",
  "estado": "California",
  "cep": "94043",
  "latitude": 37.40810928301087,
  "longitude": -122.09059575229634,
  "horas": "America/Los_Angeles",
  "mobile": false,
  "vpn": false,
  "tor": false,
  "proxy": false,
  "datacenter": true,
  "riskScore": 0
}
```

**Resposta de erro (ex.: IP inexistente/inválido)**

O status HTTP e o corpo repassam o que a `ipquery.io` retornou. Quando o provedor responde em texto puro (não-JSON), a API envolve a mensagem em JSON:

```
GET /v1/Ip/not-an-ip
```

```json
{
  "mensagem": "IP address not-an-ip not found"
}
```
`HTTP 404`

## Registro de consultas (log em MySQL)

Toda chamada ao endpoint é gravada em `LOGS.Ips` (mesmo quando o IP é inválido — nesse caso só a coluna `IP` é preenchida, o resto fica `NULL`). Colunas: `IP`, `Provedor`, `Pais`, `CEP`, `Latitude`, `Longitude`, `fl_is_mobile`, `fl_is_vpn`, `fl_is_tor`, `fl_is_provy`, `fl_is_datacenter`.

**Importante:** a coluna `id` precisa ser `AUTO_INCREMENT` (só `PRIMARY KEY` não basta, senão o insert falha). Se a tabela foi criada sem isso:

```sql
ALTER TABLE LOGS.Ips MODIFY id INT AUTO_INCREMENT;
```

A connection string fica em `ConnectionStrings:LogDb` (`appsettings.json`/`appsettings.Development.json`). Se a gravação falhar (banco fora do ar, credencial errada etc.), a API responde normalmente ao cliente e só registra o erro no log da aplicação — a consulta de IP nunca é bloqueada por causa do log.

## Tela de mapa (wwwroot/index.html)

Página estática simples servida pela própria API (`app.UseStaticFiles()`): digite um IP, ela chama `/v1/Ip/{ip}` e desenha um marcador na posição (latitude/longitude) usando **Leaflet + OpenStreetMap** — sem chave de API, sem cadastro, sem custo. Acesse em `/` com a API rodando.

## Rodando localmente

```bash
dotnet restore
dotnet run
```

Por padrão sobe em `http://localhost:5151` (perfil `http` em `Properties/launchSettings.json`). Com o app em execução e `ASPNETCORE_ENVIRONMENT=Development`, o Swagger fica disponível em `/swagger`.

Também há um arquivo `ApiIp.http` com uma requisição de exemplo, utilizável direto pelo editor (VS Code/Rider).

Pré-requisito: um MySQL acessível em `localhost:3306` com o schema `LOGS` e a tabela `Ips` (ver acima). Em dev, `appsettings.Development.json` já aponta para `root`/`root`, compatível com um container Docker MySQL padrão local.

## Estrutura de pastas

| Pasta | Responsabilidade |
|---|---|
| `Controllers/` | Endpoints HTTP (`IpController`) |
| `Services/` | Regra de negócio / orquestração (`IpService`) |
| `Rest/` | Cliente HTTP para a API externa ipquery.io (`ApiRest`) |
| `Interfaces/` | Contratos de `Service`, `Rest` e `LogRepository` para permitir troca/mocks |
| `Moldels/` | Modelos que espelham o JSON da ipquery.io (`Root`, `Location`, `Isp`, `Risk`) |
| `Dtos/` | Contratos expostos pela API (`IpResponse`, `ResponseGenerico<T>`) |
| `Mappings/` | Perfis do AutoMapper (`Root` → `IpResponse`) |
| `Repository/` | Gravação do log de consultas em MySQL (`IpLogRepository`) |
| `wwwroot/` | Página estática de visualização no mapa (`index.html`) |

## Dependências principais

- **AutoMapper 13.0.1** — mapeamento entre o modelo bruto da ipquery.io e o DTO de resposta. Ver alerta abaixo.
- **Swashbuckle.AspNetCore** — Swagger/OpenAPI.
- **MySqlConnector** — grava o histórico de consultas em `LOGS.Ips`.

## Alertas para decisão (não técnicos)

- **AutoMapper**: a versão 13.0.1 tem uma vulnerabilidade conhecida de DoS por recursão descontrolada (GHSA-rvv3-g6hj-g44x, `dotnet build` avisa). A correção só existe a partir da 15.1.1/16.1.1 — mas a partir dessas versões o AutoMapper passou a ser software comercial licenciado (LuckyPennySoftware): grátis para dev/teste, exige licença paga para uso em produção. Não fiz o upgrade sozinho por ser uma decisão de custo/compliance, não técnica. Opções: (a) comprar a licença e atualizar, (b) substituir o AutoMapper por mapeamento manual (poucas classes, seria simples) e eliminar a dependência, (c) manter como está e aceitar o risco documentado. Vale alinhar com Compliance/Financeiro antes de decidir.

## Pendências conhecidas

- `appsettings.Development.json` está versionado no Git com a credencial local (`root`/`root`) da connection string `LogDb`. Como é senha de um container Docker descartável de dev, o risco é baixo, mas o ideal é mover para User Secrets ou variável de ambiente e não versionar credencial nenhuma, mesmo de dev.

## Changelog relevante

- **Corrigido (bug de produção)**: chamadas com IP inválido faziam a API estourar exceção não tratada (`JsonException`) e responder `500` com stack trace completo, pois o código tentava desserializar como JSON uma resposta em texto puro da ipquery.io. Agora o erro é tratado e repassado como JSON (`{ "mensagem": "..." }`) com o status HTTP original.
- **Adicionado**: registro de todas as consultas (sucesso e erro) em MySQL (`LOGS.Ips`) via `IpLogRepository`, sem impacto na resposta ao cliente em caso de falha de gravação.
- **Adicionado**: tela de mapa em `wwwroot/index.html` (Leaflet + OpenStreetMap) mostrando a localização exata da última consulta.
- **Limpeza**: namespaces padronizados (`ApiIp.Controllers`, `ApiIp.Dtos` no lugar de `IpController.ControlleerBase`).
- **Limpeza**: `bin/` e `obj/` removidos do controle de versão e adicionado `.gitignore`.
- **Corrigido**: `ApiIp.http` apontava para o endpoint de exemplo do template (`weatherforecast`) em vez do endpoint real da API.
