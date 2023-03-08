using Api.Businness.Manager;
using Api.Entity.Entity;
using Api.Entity.Response;

namespace Api.Transaccion.Services
{
    public interface IServiceCuentas
    {
        Response<string> addCuenta(Cuenta cuentas);
        Response<List<Cuenta>> selectCuentas();
        Response<Cuenta> selectCuenta(string nroCuenta);
        Response<string> updateCuenta(string nroCuenta, decimal saldo);
    }
    public class ServiceCuentas : IServiceCuentas
    {
        private readonly IManagerCuentas _manager;
        public ServiceCuentas(IManagerCuentas managerCuentas)
        {
            _manager = managerCuentas;
        }

        public Response<string> addCuenta(Cuenta cuentas)
        {
            try
            {
                var response = _manager.addCuenta(cuentas);
                return Response<string>.Completed(response);
            }
            catch(Exception ex)
            {
                return Response<string>.Error(ex.Message);
            }
        }

        public Response<Cuenta> selectCuenta(string nroCuenta)
        {
            try
            {
                var response = _manager.selectCuenta(nroCuenta);
                return Response<Cuenta>.Completed(response);
            }
            catch (Exception ex)
            {
                return Response<Cuenta>.Error(ex.Message);
            }
        }

        public Response<List<Cuenta>> selectCuentas()
        {
            try
            {
                var response = _manager.selectCuentas();
                return Response<List<Cuenta>>.Completed(response);
            }
            catch (Exception ex)
            {
                return Response<List<Cuenta>>.Error(ex.Message);
            }
        }

        public Response<string> updateCuenta(string nroCuenta, decimal saldo)
        {
            try
            {
                var response = _manager.updateCuenta(nroCuenta, saldo);
                return Response<string>.Completed(response);
            }
            catch (Exception ex)
            {
                return Response<string>.Error(ex.Message);
            }
        }
    }
}
