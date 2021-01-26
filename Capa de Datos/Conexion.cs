using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace Capa_de_Datos
{
    public class Conexion
    {
        //private SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["MiCadenaDeConexion"].ToString());
        private MySqlConnection conexion { get; set; }
        private Conexion()
        {
            var config = ConfigurationManager.ConnectionStrings["MiCadenaDeConexion"].ToString();
            conexion = new MySqlConnection(config);
        }

        //SINGLETON
        private static Conexion instancia;
        public static Conexion GetInstance
        {
            get
            {
                if (instancia == null)
                    instancia = new Conexion();
                return instancia;
            }
        }
        public DataTable Leer(string comando)
        {
            DataTable tabla = new DataTable();
            try
            {
                conexion.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexion;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = comando;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                da.Fill(tabla);
                conexion.Close();
                return tabla;
            }
            catch (MySqlException ex)
            {
                conexion.Close();
                throw ex;
            }

        }
        public int Escribir(string comando)
        {
            try
            {
                conexion.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexion;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = comando;
                int filas;
                filas = cmd.ExecuteNonQuery();
                conexion.Close();
                return filas;
            }
            catch (Exception e)
            {
                conexion.Close();
                throw e;
            }
        }
        public bool EjecutarStore(string nombreStore, List<MySqlParameter> Parametros = null)
        {
            bool resultado = false;
            try
            {
                conexion.Open();
                MySqlCommand cmd = new MySqlCommand(nombreStore, conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                if (Parametros != null)
                {
                    foreach (var item in Parametros)
                    {
                        cmd.Parameters.Add(item);
                    }
                }
                int response = cmd.ExecuteNonQuery();
                resultado = true;
                conexion.Close();
            }
            catch (Exception ex)
            {
                conexion.Close();
                throw new Exception(" Error al ejecutar procedimiento almacenado ", ex);
            }

            return resultado;
        }
        public DataSet RetornarDataReaderDeStore(string nombreStore, List<MySqlParameter> Parametros = null)
        {
            try
            {
                DataSet ds = new DataSet();
                var command = new MySqlCommand(nombreStore, conexion);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                conexion.Open();
                if (Parametros != null)
                {
                    foreach (var item in Parametros)
                    {
                        command.Parameters.Add(item);
                    }
                }
                MySqlDataAdapter da = new MySqlDataAdapter(command);
                da.Fill(ds);
                conexion.Close();
                return ds;
            }
            catch (Exception e)
            {
                conexion.Close();
                throw e;
            }


        }
    }
}