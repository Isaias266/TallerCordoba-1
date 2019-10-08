using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using TallerAutos.Entities;

namespace TallerAutos.DataAccessLayer
{
    class ClienteDao
    {
        BaseDeDatos eBD = new BaseDeDatos();

        public void CargarCliente(Cliente c)
        {
            string insercionSQL = "INSERT INTO Clientes (dni, apellido, nombre, domicilio, " +
                                  "email, telefono, celular, fechaNacimiento, codSexo, borrado) " +
                                  "VALUES ('" + c.Dni + "','" + c.Apellido + "','" + c.Nombre +
                                  "','" + c.Domicilio + "','" + c.Email + "','" + c.Telefono + "','" + c.Celular +
                                  "','" + c.FechaNacimiento + "','" + c.Sexo.CodSexo + "', 0)";
            eBD.Insertar(insercionSQL);
        }

        public void ActualizarCliente(Cliente c)
        {
            string actualizacionSQL = "UPDATE Clientes " +
                                         "SET " +
                                         "nombre='" + c.Nombre + "', " +
                                         "apellido='" + c.Apellido + "', " +
                                         "domicilio='" + c.Domicilio + "', " +
                                         "email='" + c.Email + "', " +
                                         "telefono='" + c.Telefono + "', " +
                                         "celular='" + c.Celular + "', " +
                                         "fechaNacimiento='" + c.FechaNacimiento + "', " +                                        
                                         "codSexo=" + c.Sexo.CodSexo +                                        
                                         "WHERE dni=" + c.Dni;
            eBD.Insertar(actualizacionSQL);
        }

        public IList<Cliente> ConsultarClientes(string condicionesSql)
        {
            List<Cliente> listaClientes = new List<Cliente>();

            string strSql = "SELECT C.dni, " +
                                   "C.nombre, " +
                                   "C.apellido, " +
                                   "C.domicilio, " +
                                   "C.telefono, " +
                                   "C.celular, " +
                                   "C.fechaNacimiento, " +                                   
                                   "C.email, " +
                                   "C.codSexo, " +
                                   "S.nombre as nombreSexo " +
                                   "FROM Clientes C FULL JOIN Sexos S ON (C.codSexo = S.codSexo) " +
                                   "WHERE borrado = 0 ";

            strSql += condicionesSql;
            strSql += " ORDER BY C.dni DESC";

            var resultadoConsulta = (DataRowCollection)eBD.Consultar(strSql).Rows;

            foreach (DataRow row in resultadoConsulta)
            {
                if (!string.IsNullOrEmpty(row["dni"].ToString()))
                    listaClientes.Add(MappingCliente(row));
            }

            return listaClientes;
        }

        public void EliminarCliente(Cliente c)
        {
            string eliminacionSQL = "UPDATE Clientes SET borrado = 1 WHERE dni = " + c.Dni;
            eBD.Insertar(eliminacionSQL);
        }

        private Cliente MappingCliente(DataRow row)
        {
            Cliente oCliente = new Cliente();

            oCliente.Dni = Convert.ToInt32(row["dni"].ToString());
            oCliente.Nombre = row["nombre"].ToString();
            oCliente.Apellido = row["apellido"].ToString();
            oCliente.Email = row["email"].ToString();

            if (row["domicilio"].ToString() != "")
                oCliente.Domicilio = row["domicilio"].ToString();
            if (row["telefono"].ToString() != "")
                oCliente.Telefono = row["telefono"].ToString();
            if (row["celular"].ToString() != "")
                oCliente.Celular = row["celular"].ToString();
            if (row["fechaNacimiento"].ToString() != "")
                oCliente.FechaNacimiento = Convert.ToDateTime(row["fechaNacimiento"].ToString());

            oCliente.Sexo = new Sexo();
            if (row["codSexo"].ToString() != "")
                oCliente.Sexo.CodSexo = Convert.ToInt32(row["codSexo"].ToString());
            oCliente.Sexo.Nombre = row["nombreSexo"].ToString();

            return oCliente;
        }
    }
}
