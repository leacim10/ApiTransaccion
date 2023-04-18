using Api.Businness.Manager;
using Api.Entity.Entity;
using Api.Entity.Response;

namespace Api.Transaccion.Services
{
    public interface IServiceReporte
    {
        Response<ResponseReporte> selectCuenta(string nroCuenta);
    }
    public class ServiceReporte : IServiceReporte
    {
        private readonly IManagerReporte _manager;
        public ServiceReporte(IManagerReporte manager)
        {
            _manager = manager;
        }
        public Response<ResponseReporte> selectCuenta(string nroCuenta)
        {
            try
            {
                var response = _manager.reporteCuenta(nroCuenta);
                return Response<ResponseReporte>.Completed(response);
            }
            catch(Exception ex) 
            {
                return Response<ResponseReporte>.Error(ex.Message);
            }
        }
    }
}
