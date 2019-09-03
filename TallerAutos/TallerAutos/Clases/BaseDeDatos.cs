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

        //string cadenaConexion = @"Data Source=localhost;Initial Catalog=Taller;Integrated Security=True";
        string cadenaConexion = @"Data Source = LAPTOP-WINDOWS1\SQLEXPRESS;Initial Catalog=Taller; Integrated Security = True";
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
    }
}
