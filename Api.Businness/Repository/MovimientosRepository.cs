using Api.DataAccess;
using Api.Entity.Entity;
using Api.Entity.Entity.Settings;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Businness.Repository
{
    public interface IMovimientosRepository
    {
        public bool addMovimiento(Movimiento movimientos);
        public List<Movimiento> selectMovimiento(string nroCuenta);
    }
    public class MovimientosRepository : IMovimientosRepository
    {
        private Api.DataAccess.IDataAccess _dataAccess;
        private dataBaseEntity _dataBase;

        public MovimientosRepository(dataBaseEntity dataBase)
        {
            _dataBase = dataBase;

            _dataAccess = new Api.DataAccess.DataAccess(_dataBase);
        }
        /*
        #region MySql
        public bool addMovimiento(Movimiento movimientos)
        {
            try
            {
                List<MySqlParameter> lstParameter = new List<MySqlParameter>();
                lstParameter.Add(new MySqlParameter("@_nroCuenta_VC", movimientos.nroCuenta));
                lstParameter.Add(new MySqlParameter("@_fecha_DT", movimientos.fecha));
                lstParameter.Add(new MySqlParameter("@_tipo_CH", movimientos.tipo));
                lstParameter.Add(new MySqlParameter("@_importe_DC", movimientos.importe));
                
                return _dataAccess.ExecuteStoredProcedure("dbPrueba", "addMovimiento", lstParameter);
            }
            catch (Exception ex)
            {
                throw new Exception($"[addMovimiento] Error: {ex.Message}");
            }
        }

        public List<Movimiento> selectMovimiento(string nroCuenta)
        {
            try
            {
                List<Movimiento> listMovimientos = new List<Movimiento>();
                List<MySqlParameter> lstParameter = new List<MySqlParameter>();
                lstParameter.Add(new MySqlParameter("@_nroCuenta_VC", nroCuenta));
                DataTable result = _dataAccess.SelectStoredProcedire("dbPrueba", "selectMovimiento_byNroCuenta", lstParameter);
                if (result.Rows.Count > 0)
                {
                    foreach (DataRow row in result.Rows)
                    {
                        Movimiento movimientos = new Movimiento();
                        movimientos.idMovimiento = int.Parse(row["idMovimiento_IN"].ToString());
                        movimientos.nroCuenta = row["nroCuenta_VC"].ToString();
                        movimientos.fecha = DateTime.Parse(row["fecha_DT"].ToString());
                        movimientos.tipo = row["tipo_CH"].ToString();
                        movimientos.importe = decimal.Parse(row["importe_DC"].ToString());
                    }
                }
                return listMovimientos;
            }
            catch (Exception ex)
            {
                throw new Exception($"[selectMovimiento] Error: {ex.Message}");
            }
        }
        #endregion
        */


        #region SqlServer
        public bool addMovimiento(Movimiento movimientos)
        {
            try
            {
                List<SqlParameter> lstParameter = new List<SqlParameter>();
                lstParameter.Add(new SqlParameter("@_nroCuenta_VC", movimientos.nroCuenta));
                lstParameter.Add(new SqlParameter("@_fecha_DT", movimientos.fecha));
                lstParameter.Add(new SqlParameter("@_tipo_CH", movimientos.tipo));
                lstParameter.Add(new SqlParameter("@_importe_DC", movimientos.importe));

                return _dataAccess.ExecuteStoredProcedure("dbPruebaSql", "prueba.addMovimiento", lstParameter);
            }
            catch (Exception ex)
            {
                throw new Exception($"[addMovimiento] Error: {ex.Message}");
            }
        }

        public List<Movimiento> selectMovimiento(string nroCuenta)
        {
            try
            {
                List<Movimiento> listMovimientos = new List<Movimiento>();
                List<SqlParameter> lstParameter = new List<SqlParameter>();
                lstParameter.Add(new SqlParameter("@_nroCuenta_VC", nroCuenta));
                DataTable result = _dataAccess.SelectStoredProcedire("dbPruebaSql", "prueba.selectMovimiento_byNroCuenta", lstParameter);
                if (result.Rows.Count > 0)
                {
                    foreach (DataRow row in result.Rows)
                    {
                        Movimiento movimientos = new Movimiento();
                        movimientos.idMovimiento = int.Parse(row["idMovimiento_IN"].ToString());
                        movimientos.nroCuenta = row["nroCuenta_VC"].ToString();
                        movimientos.fecha = DateTime.Parse(row["fecha_DT"].ToString());
                        movimientos.tipo = row["tipo_CH"].ToString();
                        movimientos.importe = decimal.Parse(row["importe_DC"].ToString());
                    }
                }
                return listMovimientos;
            }
            catch (Exception ex)
            {
                throw new Exception($"[selectMovimiento] Error: {ex.Message}");
            }
        }
        #endregion
    }
}
