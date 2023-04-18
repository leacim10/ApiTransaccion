using Api.Entity.Entity.Settings;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.DataAccess
{
    public interface IDataAccess
    {
        //mySql
        DataTable SelectStoredProcedire(string name, string query, List<MySqlParameter> parameters);
        bool ExecuteStoredProcedure(string name, string query, List<MySqlParameter> parameters);

        //SQL SERVER
        DataTable SelectStoredProcedire(string name, string query, List<SqlParameter> parameters);
        bool ExecuteStoredProcedure(string name, string query, List<SqlParameter> parameters);
    }
    public class DataAccess : IDataAccess
    {
        private dataBaseEntity _dataBaseEntity;
        public DataAccess(dataBaseEntity dataBaseEntity) 
        {
            _dataBaseEntity = dataBaseEntity;
        }
        public string connection(conexion dataBase)
        {
            string connection = string.Empty;
            try
            {
                //MySql
                //connection = $"Server={dataBase.server};Port=3306;DataBase={dataBase.dataBase};Uid={dataBase.user};Pwd={dataBase.password};";
                
                //SqlServer
                connection = "Persist Security Info=True;User ID=" + dataBase.user + ";Pwd=" + dataBase.password + ";Server=" + dataBase.server + ";Database=" + dataBase.dataBase + ";Application Name =" + dataBase.name;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return connection;
        }

        #region mySql
        public bool ExecuteStoredProcedure(string name, string query, List<MySqlParameter> parameters)
        {
            MySqlConnection conexion = new MySqlConnection(connection(_dataBaseEntity.connections.FirstOrDefault(x => x.name == name)));
            try
            {
                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.CommandType = CommandType.StoredProcedure;
                //comando.CommandTimeout = 60000;

                if (parameters != null)
                {
                    foreach (var item in parameters)
                    {
                        if (item.Value == null)
                            item.Value = DBNull.Value;
                        comando.Parameters.Add(item);
                    }
                }

                conexion.Open();
                comando.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
                MySqlConnection.ClearAllPools();
            }
        }

        public DataTable SelectStoredProcedire(string name, string query, List<MySqlParameter> parameters)
        {
            DataTable consulta = new DataTable();
            MySqlConnection conexion = new MySqlConnection(connection(_dataBaseEntity.connections.FirstOrDefault(x => x.name == name)));
            try
            {
                MySqlConnection.ClearAllPools();
                MySqlDataAdapter comando = new MySqlDataAdapter(query, conexion);
                comando.SelectCommand.CommandType = CommandType.StoredProcedure;
                //comando.SelectCommand.CommandTimeout = 3600000;

                if (parameters != null)
                {
                    foreach (var item in parameters)
                    {
                        if (item.Value == null)
                            item.Value = DBNull.Value;
                        comando.SelectCommand.Parameters.Add(item);
                    }
                }

                conexion.Open();
                comando.Fill(consulta);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
                MySqlConnection.ClearAllPools();
            }
            return consulta;
        }
        #endregion



        #region SqlServer
        public bool ExecuteStoredProcedure(string name, string query, List<SqlParameter> parameters)
        {
            SqlConnection conexion = new SqlConnection(connection(_dataBaseEntity.connections.FirstOrDefault(x => x.name == name)));
            try
            {
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.CommandType = CommandType.StoredProcedure;
                //comando.CommandTimeout = 60000;

                if (parameters != null)
                {
                    foreach (var item in parameters)
                    {
                        if (item.Value == null)
                            item.Value = DBNull.Value;
                        comando.Parameters.Add(item);
                    }
                }

                conexion.Open();
                comando.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
                SqlConnection.ClearAllPools();
            }
        }

        public DataTable SelectStoredProcedire(string name, string query, List<SqlParameter> parameters)
        {
            DataTable consulta = new DataTable();
            SqlConnection conexion = new SqlConnection(connection(_dataBaseEntity.connections.FirstOrDefault(x => x.name == name)));
            try
            {
                SqlConnection.ClearAllPools();
                SqlDataAdapter comando = new SqlDataAdapter(query, conexion);
                comando.SelectCommand.CommandType = CommandType.StoredProcedure;
                //comando.SelectCommand.CommandTimeout = 3600000;

                if (parameters != null)
                {
                    foreach (var item in parameters)
                    {
                        if (item.Value == null)
                            item.Value = DBNull.Value;
                        comando.SelectCommand.Parameters.Add(item);
                    }
                }

                conexion.Open();
                comando.Fill(consulta);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
                SqlConnection.ClearAllPools();
            }
            return consulta;
        }
        #endregion
    }
}