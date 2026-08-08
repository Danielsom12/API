using AutoMapper;

using ApiIp.Interfaces;

using ApiIp.Dtos;

namespace ApiIp.Services;

public class IpService : IpInterfaceService
{
    private readonly IMapper _mapper;
    private readonly IpInterfaceRest _ipRest;
    private readonly IpInterfaceLogRepository _logRepository;
    private readonly ILogger<IpService> _logger;

    public IpService(IMapper mapper, IpInterfaceRest ipRest, IpInterfaceLogRepository logRepository, ILogger<IpService> logger)
    {
        _mapper = mapper;
        _ipRest = ipRest;
        _logRepository = logRepository;
        _logger = logger;
    }

    public async Task<ResponseGenerico<IpResponse>> BuscarIp(string ip)
    {
        // 1. Busca os dados brutos vindo do REST
        var response = await _ipRest.BuscarIp(ip);

        // 2. Mapeia a resposta bruta/model para o DTO (IpResponse)
        var resultado = _mapper.Map<ResponseGenerico<IpResponse>>(response);

        // 3. Registra a consulta no banco (sucesso ou erro), sem afetar a resposta ao cliente
        try
        {
            await _logRepository.RegistrarAsync(ip, resultado.DadosRetorno);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Falha ao registrar consulta do IP {Ip} no banco de logs", ip);
        }

        return resultado;
    }
}