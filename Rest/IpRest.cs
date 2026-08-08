using ApiIp.Dtos;
using ApiIp.Interfaces;
using ApiIp.Models;
using System.Dynamic;
using System.Text.Json;

namespace ApiIp.Rest;

public class ApiRest : IpInterfaceRest
{
    private static readonly JsonSerializerOptions _jsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public async Task<ResponseGenerico<Root>> BuscarIp(string ip)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.ipquery.io/{ip}");
        var response = new ResponseGenerico<Root>();

        using (var client = new HttpClient())
        {
            var responseIpApi = await client.SendAsync(request);
            var contentResp = await responseIpApi.Content.ReadAsStringAsync();

            if (responseIpApi.IsSuccessStatusCode)
            {
                var objResponse = JsonSerializer.Deserialize<Root>(contentResp, _jsonOptions);
                response.CodigoHttp = responseIpApi.StatusCode;
                response.DadosRetorno = objResponse;
            }
            else
            {
                response.CodigoHttp = responseIpApi.StatusCode;
                response.ErroRetorno = ParseErro(contentResp);
            }
        }

        return response;
    }

    private static ExpandoObject ParseErro(string contentResp)
    {
        try
        {
            return JsonSerializer.Deserialize<ExpandoObject>(contentResp, _jsonOptions)
                ?? new ExpandoObject();
        }
        catch (JsonException)
        {
            dynamic erro = new ExpandoObject();
            erro.mensagem = contentResp;
            return erro;
        }
    }
}