
using ApiIp.Dtos;

namespace ApiIp.Interfaces;

public interface IpInterfaceService
{
    Task<ResponseGenerico<IpResponse>> BuscarIp(string ip);
}