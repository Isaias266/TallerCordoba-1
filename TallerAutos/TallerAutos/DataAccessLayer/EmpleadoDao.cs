using System;
using System.Collections.Generic;
using System.Data;
using TallerAutos.Entities;
using System.Windows.Forms;

namespace TallerAutos.DataAccessLayer
{
    class EmpleadoDao
    {
        BaseDeDatos eBD = new BaseDeDatos();

        public Empleado ValidarEmpleado(string us, string pa)
        {
            string strSql = "SELECT E.legajo, " +
                                   "E.nombre as nombreEmpleado, " +
                                   "E.apellido, " +
                                   "E.domicilio, " +
                                   "E.telefono, " +
                                   "E.celular, " +
                                   "E.fechaNacim, " +
                                   "E.fechaAlta, " +
                                   "E.usuario, " +
                                   "E.rol, " +
                                   "R.nombre as nombreRol, " +
                                   "E.codSexo, " +
                                   "S.nombre as nombreSexo, " +
                                   "E.password " +
                                   "FROM Empleados E JOIN Roles R ON (E.rol = R.codRol) " +
                                   "FULL JOIN Sexos S ON (E.codSexo = S.codSexo) " +
                                   "WHERE borrado = 0 AND usuario='" + us + "' AND password='" + pa + "'";

            DataTable tabla = eBD.Consultar(strSql);
            if (tabla.Rows.Count > 0)
                return MappingEmpleado(tabla.Rows[0]);
            else
                return null;
        }

        
        public void CargarEmpleado(Empleado e)
        {
            string insercionSQL = "INSERT INTO Empleados (rol, nombre, apellido, domicilio, " +
                                  "telefono, celular, fechaNacim, fechaAlta, codSexo, usuario, password) " +
                                  "VALUES ('" + e.Rol.CodRol + "','" + e.Nombre + "','" + e.Apellido + 
                                  "','" + e.Domicilio + "','" + e.Telefono + "','" + e.Celular + 
                                  "','" + e.FechaNacim + "','" + e.FechaAlta + "','" + e.Sexo.CodSexo + 
                                  "','" + e.Usuario + "','" + e.Password + "')";
            eBD.Insertar(insercionSQL);
        }

        public void ActualizarEmpleado(Empleado e)
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
            eBD.Insertar(actualizacionSQL);
        }

        public IList<Empleado> ConsultarEmpleados(string condicionesSql)
        {
            List<Empleado> listaEmpleados = new List<Empleado>();

            string strSql = "SELECT E.legajo, " +
                                   "E.nombre as nombreEmpleado, " +
                                   "E.apellido, " +
                                   "E.domicilio, " +
                                   "E.telefono, " +
                                   "E.celular, " +
                                   "E.fechaNacim, " +
                                   "E.fechaAlta, " +
                                   "E.usuario, " +
                                   "E.rol, " +
                                   "R.nombre as nombreRol, " +
                                   "E.codSexo, " +
                                   "S.nombre as nombreSexo, " +
                                   "E.password " +
                                   "FROM Empleados E JOIN Roles R ON (E.rol = R.codRol) " +
                                   "FULL JOIN Sexos S ON (E.codSexo = S.codSexo) " +
                                   "WHERE borrado = 0 ";

            strSql += condicionesSql;
            strSql += " ORDER BY E.fechaAlta DESC";

            var resultadoConsulta = (DataRowCollection)eBD.Consultar(strSql).Rows;

            foreach(DataRow row in resultadoConsulta)
            {
                if(!string.IsNullOrEmpty(row["legajo"].ToString()))
                    listaEmpleados.Add(MappingEmpleado(row));
            }

            return listaEmpleados;
        }

        public void EliminarEmpleado(Empleado e)
        {
            string eliminacionSQL = "UPDATE Empleados SET borrado = 1 WHERE legajo = " + e.Legajo;
            eBD.Insertar(eliminacionSQL);
        }

        public bool ValidarUserEmpleado(string nombreUsuario)
        {

            String strSql = string.Concat(" SELECT legajo, ",
                                          "        rol, ",
                                          "        nombre ",
                                          "FROM Empleados WHERE borrado = 0");


            strSql += " AND usuario=" + "'" + nombreUsuario + "'";
            
            var resultado = eBD.Consultar(strSql);

            if (resultado.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private Empleado MappingEmpleado(DataRow row)
        {
            Empleado oEmpleado = new Empleado();

            oEmpleado.Legajo = Convert.ToInt32(row["legajo"].ToString());
            oEmpleado.Nombre = row["nombreEmpleado"].ToString();
            oEmpleado.Apellido = row["apellido"].ToString();

            oEmpleado.Rol = new Rol();
            oEmpleado.Rol.CodRol = Convert.ToInt32(row["rol"].ToString());
            oEmpleado.Rol.Nombre = row["nombreRol"].ToString();
            
            if (row["domicilio"].ToString() != "")
                oEmpleado.Domicilio = row["domicilio"].ToString();
            if (row["telefono"].ToString() != "")
                oEmpleado.Telefono = row["telefono"].ToString();
            if (row["celular"].ToString() != "")
                oEmpleado.Celular = row["celular"].ToString();
            if (row["fechaNacim"].ToString() != "")
                oEmpleado.FechaNacim = Convert.ToDateTime(row["fechaNacim"].ToString());
            
            oEmpleado.FechaAlta = Convert.ToDateTime(row["fechaAlta"].ToString());

            oEmpleado.Sexo = new Sexo();
            oEmpleado.Sexo.CodSexo = Convert.ToInt32(row["codSexo"].ToString());
            oEmpleado.Sexo.Nombre = row["nombreSexo"].ToString();
          
            oEmpleado.Usuario = row["usuario"].ToString();
            oEmpleado.Password = row["password"].ToString();
            
            return oEmpleado;
        }
    }
}
