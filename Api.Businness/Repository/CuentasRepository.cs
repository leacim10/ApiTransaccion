using Api.Entity.Entity;
using Api.Entity.Entity.Settings;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Businness.Repository
{
    public interface ICuentasRepository
    {
        public bool addCuenta(Cuenta cuentas);
        public List<Cuenta> selectCuentas();
        public Cuenta selectCuenta(string nroCuenta);
        public bool updateCuenta(string nroCuenta, decimal saldo);
    }
    public class CuentasRepository : ICuentasRepository
    {
        private Api.DataAccess.IDataAccess _dataAccess;
        private dataBaseEntity _dataBase;
        public CuentasRepository(dataBaseEntity dataBase)
        {
            _dataBase = dataBase;

            _dataAccess = new Api.DataAccess.DataAccess(_dataBase);
        }
        public bool addCuenta(Cuenta cuentas)
        {
            try
            {
                List<MySqlParameter> lstParameter = new List<MySqlParameter>();
                lstParameter.Add(new MySqlParameter("@_nroCuenta_VC", cuentas.nroCuenta));
                lstParameter.Add(new MySqlParameter("@_tipo_CH", cuentas.tipo));
                lstParameter.Add(new MySqlParameter("@_moneda_CH", cuentas.moneda));
                lstParameter.Add(new MySqlParameter("@_nombre_DC", cuentas.nombre));
                lstParameter.Add(new MySqlParameter("@_saldo_DC", cuentas.saldo));

                return _dataAccess.ExecuteStoredProcedure("dbPrueba", "addCuentas", lstParameter);
            }
            catch (Exception ex)
            {
                throw new Exception($"[addCuenta] Error: {ex.Message}");
            }
        }

        public Cuenta selectCuenta(string nroCuenta)
        {
            try
            {
                List<MySqlParameter> lstParameter = new List<MySqlParameter>();
                lstParameter.Add(new MySqlParameter("@_nroCuenta_VC", nroCuenta));
                DataTable result = _dataAccess.SelectStoredProcedire("dbPrueba", "selectCuenta_byNroCuenta", lstParameter);
                if (result.Rows.Count > 0)
                {
                    DataRow row = result.Rows[0];
                    Cuenta cuentas = new Cuenta();
                    cuentas.nroCuenta = row["nroCuenta_VC"].ToString();
                    cuentas.tipo = row["tipo_CH"].ToString();
                    cuentas.moneda = row["moneda_CH"].ToString();
                    cuentas.nombre = row["nombre_DC"].ToString();
                    cuentas.saldo = decimal.Parse(row["saldo_DC"].ToString());

                    return cuentas;
                }
                else
                {
                    throw new Exception($"No se trajo registros del SP: \"selectCuenta_byNroCuenta\"");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"[selectCuenta] Error: {ex.Message}");
            }
        }

        public List<Cuenta> selectCuentas()
        {
            try
            {
                List<Cuenta> listCuentas = new List<Cuenta>();
                List<MySqlParameter> lstParameter = new List<MySqlParameter>();
                DataTable result = _dataAccess.SelectStoredProcedire("dbPrueba", "selectCuentas", lstParameter);
                if (result.Rows.Count > 0)
                {
                    foreach (DataRow row in result.Rows)
                    {
                        Cuenta cuentas = new Cuenta();
                        cuentas.nroCuenta = row["nroCuenta_VC"].ToString();
                        cuentas.tipo = row["tipo_CH"].ToString();
                        cuentas.moneda = row["moneda_CH"].ToString();
                        cuentas.nombre = row["nombre_DC"].ToString();
                        cuentas.saldo = decimal.Parse(row["saldo_DC"].ToString());
                        listCuentas.Add(cuentas);
                    }
                }
                return listCuentas;
            }
            catch (Exception ex)
            {
                throw new Exception($"[selectCuentas] Error: {ex.Message}");
            }
        }

        public bool updateCuenta(string nroCuenta, decimal saldo)
        {
            try
            {
                List<MySqlParameter> lstParameter = new List<MySqlParameter>();
                lstParameter.Add(new MySqlParameter("@_nroCuenta_VC", nroCuenta));
                lstParameter.Add(new MySqlParameter("@_saldo_DC", saldo));
                return _dataAccess.ExecuteStoredProcedure("dbPrueba", "updateCuenta_byNroCuenta", lstParameter);
            }
            catch (Exception ex)
            {
                throw new Exception($"[updateCuenta] Error: {ex.Message}");
            }
        }
    }
}
