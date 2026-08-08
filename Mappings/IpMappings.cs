using AutoMapper;
using ApiIp.Models;
using ApiIp.Dtos;

namespace ApiIp.Mappings;

public class IpMapping : Profile
{
    public IpMapping()
    {
        // 1. Mapeamento do tipo genérico da resposta
        CreateMap(typeof(ResponseGenerico<>), typeof(ResponseGenerico<>));

        // 2. Mapeamento direto de Root -> IpResponse
        CreateMap<Root, IpResponse>()
            .ForMember(dest => dest.Provedor, opt => opt.MapFrom(src => src.Isp != null ? src.Isp.Provedor : null))
            .ForMember(dest => dest.Pais, opt => opt.MapFrom(src => src.Location != null ? src.Location.Pais : null))
            .ForMember(dest => dest.SiglaPais, opt => opt.MapFrom(src => src.Location != null ? src.Location.SiglaPais : null))
            .ForMember(dest => dest.Cidade, opt => opt.MapFrom(src => src.Location != null ? src.Location.Cidade : null))
            .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.Location != null ? src.Location.Estado : null))
            .ForMember(dest => dest.CEP, opt => opt.MapFrom(src => src.Location != null ? src.Location.CEP : null))            
            .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Location != null ? src.Location.Latitude : 0))
            .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.Location != null ? src.Location.Longitude : 0))
            .ForMember(dest => dest.Horas, opt => opt.MapFrom(src => src.Location != null ? src.Location.Horas : null))
            .ForMember(dest => dest.Mobile, opt => opt.MapFrom(src => src.Risco != null && src.Risco.Mobile))
            .ForMember(dest => dest.Vpn, opt => opt.MapFrom(src => src.Risco != null && src.Risco.Vpn))
            .ForMember(dest => dest.Tor, opt => opt.MapFrom(src => src.Risco != null && src.Risco.Tor))
            .ForMember(dest => dest.Proxy, opt => opt.MapFrom(src => src.Risco != null && src.Risco.Proxy))
            .ForMember(dest => dest.Datacenter, opt => opt.MapFrom(src => src.Risco != null && src.Risco.Datacenter))
            .ForMember(dest => dest.RiskScore, opt => opt.MapFrom(src => src.Risco != null ? src.Risco.RiskScore : 0));
    }
}