using Api.Businness.Manager;
using Api.Entity.Entity;
using Api.Entity.Response;

namespace Api.Transaccion.Services
{
    public interface IServiceMovimientos
    {
        Response<string> addMovimiento(Movimiento movimientos);
        Response<List<Movimiento>> selectMovimiento(string nroCuenta);
    }
    public class ServiceMovimientos : IServiceMovimientos
    {
        private readonly IManagerMovimientos _manager;
        public ServiceMovimientos(IManagerMovimientos manager)
        {
            _manager = manager;
        }

        public Response<string> addMovimiento(Movimiento movimientos)
        {
            try
            {
                var response = _manager.addMovimiento(movimientos);
                return Response<string>.Completed(response);
            }
            catch (Exception ex)
            {
                return Response<string>.Error(ex.Message);
            }
        }

        public Response<List<Movimiento>> selectMovimiento(string nroCuenta)
        {
            try
            {
                var response = _manager.selectMovimiento(nroCuenta);
                return Response<List<Movimiento>>.Completed(response);
            }
            catch (Exception ex)
            {
                return Response<List<Movimiento>>.Error(ex.Message);
            }
        }
    }
}
