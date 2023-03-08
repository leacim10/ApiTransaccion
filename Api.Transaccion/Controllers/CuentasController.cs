using Api.Transaccion.Services;
using Api.Entity.Response;
using Microsoft.AspNetCore.Mvc;
using Api.Entity.Entity;
using Api.Entity.Request;

namespace Api.Transaccion.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CuentasController : ControllerBase
    {
        private readonly IServiceCuentas _service;
        public CuentasController(IServiceCuentas services)
        {
            _service = services;
        }

        [HttpPost("AñadirCuenta")]
        [ProducesResponseType(typeof(Response<string>), 200)]
        public IActionResult addCuenta([FromBody] Cuenta request)
        {
            try
            {
                var response = _service.addCuenta(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("ListarCuentas")]
        [ProducesResponseType(typeof(Response<List<Cuenta>>), 200)]
        public IActionResult selectCuentas()
        {
            try
            {
                var response = _service.selectCuentas();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("TraerCuenta")]
        [ProducesResponseType(typeof(Response<Cuenta>), 200)]
        public IActionResult selectCuenta([FromBody] nroCuentaRequest request)
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

        [HttpPost("ActualizarCuenta")]
        [ProducesResponseType(typeof(Response<string>), 200)]
        public IActionResult updateCuenta([FromBody] saldoCuentaRequest request)
        {
            try
            {
                var response = _service.updateCuenta(request.nroCuenta, request.saldo);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
