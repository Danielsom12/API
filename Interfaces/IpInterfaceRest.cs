using ApiIp.Models;
using IpController.ControlleerBase;

namespace ApiIp.Interfaces;

public interface IpInterfaceRest
{
    Task<ResponseGenerico<Root>> BuscarIp(string ip);
}