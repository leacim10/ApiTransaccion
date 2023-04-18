using Api.Entity.Entity;
using Api.Entity.Request;
using Api.Entity.Response;
using Api.Transaccion.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Transaccion.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Authorize]
    public class MovimientosController : ControllerBase
    {
        private readonly IServiceMovimientos _service;
        public MovimientosController(IServiceMovimientos service) 
        {
            _service = service;
        }

        [HttpPost("AñadirMovimiento")]
        [ProducesResponseType(typeof(Response<string>), 200)]
        public IActionResult addMovimiento([FromBody] Movimiento request)
        {
            try
            {
                var response = _service.addMovimiento(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("ListarMovimientos")]
        [ProducesResponseType(typeof(Response<List<Movimiento>>), 200)]
        public IActionResult selectMovimiento([FromBody] nroCuentaRequest request)
        {
            try
            {
                var response = _service.selectMovimiento(request.nroCuenta);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
