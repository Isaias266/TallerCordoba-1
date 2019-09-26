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

        public void cargarEmpleado(Empleado e)
        {
            string insercionSQL = "INSERT INTO Empleados (rol, nombre, apellido, domicilio, " +
                                  "telefono, celular, fechaNacim, fechaAlta, codSexo, usuario, password) " +
                                  "VALUES ('" + e.Rol.CodRol + "','" + e.Nombre + "','" + e.Apellido +
                                  "','" + e.Domicilio + "','" + e.Telefono + "','" + e.Celular +
                                  "','" + e.FechaNacim + "','" + e.FechaAlta + "','" + e.Sexo.CodSexo +
                                  "','" + e.Usuario + "','" + e.Password + "')";
            eBD.insertar(insercionSQL);
        }

        public void actualizarEmpleado(Empleado e)
        {
            string actualizacionSQL = "UPDATE Empleados " +
                                         "SET rol=" + e.Rol.CodRol + ", " +
                                         "nombre='" + e.Nombre + "', " +
                                         "apellido='" + e.Apellido + "', " +
                                         "domicilio='" + e.Domicilio + "', " +
                                         "telefono='" + e.Telefono + "', " +
                                         "celular='" + e.Celular + "', " +
                                         "fechaNacim='" + e.FechaNacim + "', " +
                                         "fechaAlta='" + e.FechaAlta + "', " +
                                         "codSexo=" + e.Sexo.CodSexo + ", " +
                                         "usuario='" + e.Usuario + "', " +
                                         "password='" + e.Password + "' " +
                                         "WHERE legajo=" + e.Legajo;
            eBD.insertar(actualizacionSQL);
        }

        public IList<Cliente> consultarClientes(string condicionesSql)
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

            var resultadoConsulta = (DataRowCollection)eBD.consultar(strSql).Rows;

            foreach (DataRow row in resultadoConsulta)
            {
                if (!string.IsNullOrEmpty(row["dni"].ToString()))
                    listaClientes.Add(mappingCliente(row));
            }

            return listaClientes;
        }

        public void eliminarEmpleado(Empleado e)
        {
            string eliminacionSQL = "UPDATE Empleados SET borrado = 1 WHERE legajo = " + e.Legajo;
            eBD.insertar(eliminacionSQL);
        }

        public bool validarUserEmpleado(string nombreUsuario)
        {

            String strSql = string.Concat(" SELECT legajo, ",
                                          "        rol, ",
                                          "        nombre ",
                                          "FROM Empleados WHERE borrado = 0");


            strSql += " AND usuario=" + "'" + nombreUsuario + "'";

            var resultado = eBD.consultar(strSql);

            if (resultado.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private Cliente mappingCliente(DataRow row)
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
