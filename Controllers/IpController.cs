using ApiIp.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiIp.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class IpController : ControllerBase
    {  
        private readonly IpInterfaceService _ipService; // Boa prática: usar private readonly

        public IpController(IpInterfaceService ipService)
        {
            _ipService = ipService;
        }

        // CORRIGIDO: Adicionado o [HttpGet("{ip}")] especificando o verbo HTTP e o parâmetro da rota
        [HttpGet("{ip}")]
        public async Task<IActionResult> BuscarIp([FromRoute] string ip)
        {
            var response = await _ipService.BuscarIp(ip);

            if (response.CodigoHttp == System.Net.HttpStatusCode.OK)
            {
                return Ok(response.DadosRetorno);
            }
            
            return StatusCode((int)response.CodigoHttp, response.ErroRetorno);
        }
    }
}