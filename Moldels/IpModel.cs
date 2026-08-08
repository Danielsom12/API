using System.Text.Json.Serialization;

namespace ApiIp.Models
{
    public class Isp
    {
        [JsonPropertyName("org")]
        public string? Provedor { get; set; }
    }

    public class Location
    {
        [JsonPropertyName("country")]
        public string? Pais { get; set; }

        [JsonPropertyName("country_code")]
        public string? SiglaPais { get; set; }

        [JsonPropertyName("city")]
        public string? Cidade { get; set; }

        [JsonPropertyName("state")]
        public string? Estado { get; set; }

        [JsonPropertyName("zipcode")]
        public string? CEP { get; set; }

        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }

        [JsonPropertyName("timezone")]
        public string? Horas { get; set; }

        [JsonPropertyName("localtime")]
        public DateTime DataLocal { get; set; }
    }

    public class Risk
    {
        [JsonPropertyName("is_mobile")]
        public bool Mobile { get; set; }

        [JsonPropertyName("is_vpn")]
        public bool Vpn { get; set; }

        [JsonPropertyName("is_tor")]
        public bool Tor { get; set; }

        [JsonPropertyName("is_proxy")]
        public bool Proxy { get; set; }

        [JsonPropertyName("is_datacenter")]
        public bool Datacenter { get; set; }

        [JsonPropertyName("risk_score")]
        public int RiskScore { get; set; }
    }

    public class Root
    {
        [JsonPropertyName("ip")]
        public string? Ip { get; set; }

        [JsonPropertyName("isp")]
        public Isp? Isp { get; set; }

        [JsonPropertyName("location")]
        public Location? Location { get; set; }

        [JsonPropertyName("risk")]
        public Risk? Risco { get; set; }
    }
}