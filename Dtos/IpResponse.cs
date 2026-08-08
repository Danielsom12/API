using System.Text.Json.Serialization;

namespace ApiIp.Dtos
{
    public class IpResponse
    {
        public string? Provedor { get; set; }
        public string? Pais { get; set; }
        public string? SiglaPais { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public string? CEP { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string? Horas { get; set; }

        [JsonIgnore]
        public DateTime DataLocal { get; set; }
        public bool Mobile { get; set; }
        public bool Vpn { get; set; }
        public bool Tor { get; set; }
        public bool Proxy { get; set; }
        public bool Datacenter { get; set; }
        public int RiskScore { get; set; }
    }
}