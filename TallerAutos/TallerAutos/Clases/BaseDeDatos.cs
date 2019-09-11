using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace TallerAutos.Clases
{
    class BaseDeDatos
    {
        // mauri:
        string cadenaConexion = @"Data Source=localhost;Initial Catalog=Taller;Integrated Security=True";
        //isa:
        //string cadenaConexion = @"Data Source=(local)\SQLEXPRESS;Initial Catalog = 'Taller PAV'; Integrated Security = True";
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

            this.conectar();
            comando.CommandText = consultaSQL;
            DataTable tabla = new DataTable();
            tabla.Load(comando.ExecuteReader());
            this.desconectar();
            return tabla;


        }

        public void insertar(string insercionSQL)
        {
            this.conectar();
            comando.CommandText = insercionSQL;
            comando.ExecuteNonQuery();
            this.desconectar();
        }


        public DataTable consultarTabla(string nombreTabla)
        {

            this.conectar();
            comando.CommandText = "SELECT * FROM " + nombreTabla;
            DataTable tabla = new DataTable();
            tabla.Load(comando.ExecuteReader());
            this.desconectar();
            return tabla;
        }

            public DataTable ConsultaSQLConParametros(string sqlStr, Dictionary<string, object> prs)
            {
                SqlConnection cnn = new SqlConnection();
                SqlCommand cmd = new SqlCommand();
                DataTable tabla = new DataTable();

                try
                {
                    cnn.ConnectionString = cadenaConexion;
                    cnn.Open();
                    cmd.Connection = cnn;

                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sqlStr;

                    //Agregamos a la colección de parámetros del comando los filtros recibidos
                    foreach (var item in prs)
                    {
                        cmd.Parameters.AddWithValue(item.Key, item.Value);
                    }

                    tabla.Load(cmd.ExecuteReader());
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
