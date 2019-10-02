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

        SqlConnection conexion = new SqlConnection();
        SqlCommand comando = new SqlCommand();

        private void conectar()
        {
            conexion.ConnectionString = cadenaConexion;
            conexion.Open();
            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
        }

        private void desconectar()
        {
            conexion.Close();
        }


        public DataTable consultar(string consultaSQL)
        {
            try
            {
                this.conectar();
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
                this.desconectar();
            }
        }

        public void insertar(string insercionSQL)
        {
            try
            {
                this.conectar();
                comando.CommandText = insercionSQL;
                comando.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw (ex);
            }
            finally
            {
                this.desconectar();
            }
        }

            public DataTable consultarTabla(string nombreTabla)
        {
            try
            {
                this.conectar();
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
                this.desconectar();
            }
        }

        public DataTable ConsultaSQLConParametros(string sqlStr, Dictionary<string, object> prs)
        {
            DataTable tabla = new DataTable();

            try
            {
                this.conectar();
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
                this.desconectar();
            }
        }
    }
}
