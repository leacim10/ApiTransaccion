using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Api.Entity.Response;
using Api.Entity.Request;
using Api.Transaccion.Services;

namespace Api.Transaccion.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Authorize]
    public class ReporteController : ControllerBase
    {
        private readonly IServiceReporte _service;
        public ReporteController(IServiceReporte services) 
        {
            _service = services;
        }

        [HttpPost("ReporteCuenta")]
        [ProducesResponseType(typeof(Response<ResponseReporte>), 200)]
        public IActionResult reporteCuenta([FromBody] nroCuentaRequest request) 
        {
            try
            {
                var response = _service.selectCuenta(request.nroCuenta);
                return Ok(response);
            }
            catch (Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
