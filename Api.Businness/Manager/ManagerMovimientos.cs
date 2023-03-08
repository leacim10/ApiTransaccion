using Api.Businness.Repository;
using Api.Entity.Entity;
using Api.Entity.Entity.Settings;
using Api.Logger;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Businness.Manager
{
    public interface IManagerMovimientos
    {
        public string addMovimiento(Movimiento movimientos);
        public List<Movimiento> selectMovimiento(string nroCuenta);
    }
    public class ManagerMovimientos : IManagerMovimientos
    {
        private IMovimientosRepository _repository;

        private readonly dataBaseEntity _dataBase;
        private static readonly string _selectionDataBase = "dataBase";

        private readonly ILogger _logger;

        public ManagerMovimientos(IConfiguration configuration, ILogger logger)
        {
            _logger = logger;

            _dataBase = new dataBaseEntity();
            configuration.GetSection(_selectionDataBase).Bind(_dataBase);

            _repository = new MovimientosRepository(_dataBase);
        }

        public string addMovimiento(Movimiento movimientos)
        {
            try
            {
                return _repository.addMovimiento(movimientos) ? $"" : $"";
            }
            catch (Exception ex)
            {
                _logger.Error($"[addMovimiento] Error: {ex.Message}");
                throw ex;
            }
        }

        public List<Movimiento> selectMovimiento(string nroCuenta)
        {
            try
            {
                return _repository.selectMovimiento(nroCuenta);
            }
            catch (Exception ex)
            {
                _logger.Error($"[selectMovimiento] Error: {ex.Message}");
                throw ex;
            }
        }
    }
}
