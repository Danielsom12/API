using ApiIp.Dtos;

namespace ApiIp.Interfaces;

public interface IpInterfaceLogRepository
{
    Task RegistrarAsync(string ip, IpResponse? dados);
}
