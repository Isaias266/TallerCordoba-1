using System;
using System.Collections.Generic;
using System.Data;

namespace TallerAutos.DataAccessLayer
{
    class RolDao
    {

        BaseDeDatos sDB = new BaseDeDatos();

        public List<Rol> recuperarRoles()
        {
            List<Rol> listaRoles = new List<Rol>();
            DataTable tabla = new DataTable();
            tabla = sDB.consultarTabla("Roles");
            foreach (DataRow row in tabla.Rows)
            {
                listaRoles.Add(MappingRol(row));
            }

            return listaRoles;
        }

        private Rol MappingRol(DataRow row)
        {
            Rol oRol = new Rol
            {
                CodRol = Convert.ToInt32(row["codRol"].ToString()),
                Nombre = row["nombre"].ToString(),
                Descripcion = row["descripcion"].ToString()
            };

            return oRol;
        }
    }
}
