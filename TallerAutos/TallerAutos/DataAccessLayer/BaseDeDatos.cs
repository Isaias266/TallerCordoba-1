using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace TallerAutos.DataAccessLayer
{
    class BaseDeDatos
    {
        // mauri:
        string cadenaConexion = @"Data Source=localhost;Initial Catalog=Taller;Integrated Security=True";
        //isa:
        //string cadenaConexion = @"Data Source=(local)\SQLEXPRESS;Initial Catalog=Taller;Integrated Security=True";
        //francisco:
        //string cadenaConexion = @"Data Source=LAPTOP-WINDOWS1\SQLEXPRESS;Initial Catalog=Taller;Integrated Security=True";

        private SqlConnection conexion = new SqlConnection();
        private SqlCommand comando = new SqlCommand();
        private SqlTransaction transacionDb;

        private void Conectar()
        {
            conexion.ConnectionString = cadenaConexion;
            conexion.Open();
            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
        }

        private void Desconectar()
        {
            conexion.Close();
        }

        public void ComenzarTransaccion()
        {
            if (conexion.State == ConnectionState.Open)
                transacionDb = conexion.BeginTransaction();
        }

        public void Commit()
        {
            if (transacionDb != null)
                transacionDb.Commit();
        }

        public void Rollback()
        {
            if (transacionDb != null)
                transacionDb.Rollback();
        }

        public DataTable Consultar(string consultaSQL)
        {
            try
            {
                this.Conectar();
                comando.CommandText = consultaSQL;
                DataTable tabla = new DataTable();
                Console.WriteLine("\n\n\n" + consultaSQL + "\n\n\n");
                tabla.Load(comando.ExecuteReader());
                return tabla;
            }
            catch(SqlException ex)
            {
                throw (ex);
            }
            finally
            {
                this.Desconectar();
            }
        }

        public void Insertar(string insercionSQL)
        {
            try
            {
                this.Conectar();
                comando.CommandText = insercionSQL;
                Console.WriteLine("\n\n\n" + insercionSQL + "\n\n\n");
                comando.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw (ex);
            }
            finally
            {
                this.Desconectar();
            }
        }

        public DataTable ConsultarTabla(string nombreTabla)
        {
            try
            {
                this.Conectar();
                comando.CommandText = "SELECT * FROM " + nombreTabla;
                DataTable tabla = new DataTable();
                tabla.Load(comando.ExecuteReader());
                return tabla;
            }
            catch (SqlException ex)
            {
                throw (ex);
            }
            finally
            {
                this.Desconectar();
            }
        }

        public DataTable ConsultaSQLConParametros(string sqlStr, Dictionary<string, object> prs)
        {
            DataTable tabla = new DataTable();

            try
            {
                this.Conectar();
                comando.CommandText = sqlStr;

                //Agregamos a la colección de parámetros del comando los filtros recibidos
                foreach (var item in prs)
                {
                    comando.Parameters.AddWithValue(item.Key, item.Value);
                }

                tabla.Load(comando.ExecuteReader());
                return tabla;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                this.Desconectar();
            }
        }
    }
}
