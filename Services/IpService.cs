using AutoMapper;

using ApiIp.Interfaces;

using IpController.ControlleerBase;

namespace ApiIp.Services;

public class IpService : IpInterfaceService
{
    private readonly IMapper _mapper;
    private readonly IpInterfaceRest _ipRest;

    public IpService(IMapper mapper, IpInterfaceRest ipRest)
    {
        _mapper = mapper;
        _ipRest = ipRest;
    }

    public async Task<ResponseGenerico<IpResponse>> BuscarIp(string ip)
    {
        // 1. Busca os dados brutos vindo do REST
        var response = await _ipRest.BuscarIp(ip);

        // 2. Mapeia a resposta bruta/model para o DTO (IpResponse)
        return _mapper.Map<ResponseGenerico<IpResponse>>(response);
    }
}