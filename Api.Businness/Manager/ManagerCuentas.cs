using Api.Businness.Repository;
using Api.Entity.Entity;
using Api.Entity.Entity.Settings;
using Api.Logger;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Api.Businness.Manager
{
    public interface IManagerCuentas
    {
        public string addCuenta(Cuenta cuentas);
        public List<Cuenta> selectCuentas();
        public Cuenta selectCuenta(string nroCuenta);
        public string updateCuenta(string nroCuenta, decimal saldo);
    }
    public class ManagerCuentas : IManagerCuentas
    {
        private ICuentasRepository _repository;

        private readonly dataBaseEntity _dataBase;
        private static readonly string _sectionDataBase = "dataBase";

        private readonly ILogger _logger;

        public ManagerCuentas(IConfiguration configuration, ILogger logger)
        {
            _logger = logger;

            _dataBase = new dataBaseEntity();
            configuration.GetSection(_sectionDataBase).Bind(_dataBase);

            _repository = new CuentasRepository(_dataBase);
        }

        public string addCuenta(Cuenta cuentas)
        {
            try
            {
                return _repository.addCuenta(cuentas) ? "La cuenta se guardo correctamente." : "Se tuvo problemas al guardar la cuenta.";
            }
            catch (Exception ex)
            {
                _logger.Error($"[addCuenta] Error: {ex.Message}");
                throw ex;
            }
        }

        public List<Cuenta> selectCuentas()
        {
            try
            {
                return _repository.selectCuentas();
            }
            catch (Exception ex)
            {
                _logger.Error($"[selectCuentas] Error: {ex.Message}");
                throw ex;
            }
        }

        public Cuenta selectCuenta(string nroCuenta)
        {
            try
            {
                return _repository.selectCuenta(nroCuenta);
            }
            catch (Exception ex)
            {
                _logger.Error($"[selectCuenta] Error: {ex.Message}");
                throw ex;
            }
        }

        public string updateCuenta(string nroCuenta, decimal saldo)
        {
            try
            {
                return _repository.updateCuenta(nroCuenta, saldo) ? $"El saldo de la cuenta {nroCuenta} fue actualizado." : $"Se tuvo problemas al actuañizar el saldo de la cuenta {nroCuenta}.";
            }
            catch (Exception ex)
            {
                _logger.Error($"[updateCuenta] Error: {ex.Message}");
                throw ex;
            }
        }
    }
}
