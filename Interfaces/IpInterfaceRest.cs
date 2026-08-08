using ApiIp.Models;
using ApiIp.Dtos;

namespace ApiIp.Interfaces;

public interface IpInterfaceRest
{
    Task<ResponseGenerico<Root>> BuscarIp(string ip);
}