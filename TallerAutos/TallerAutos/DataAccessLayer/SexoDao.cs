using System;
using System.Collections.Generic;
using System.Data;

namespace TallerAutos.DataAccessLayer
{
    class SexoDao
    {

        BaseDeDatos sDB = new BaseDeDatos();

        public List<Sexo> recuperarSexos()
        {
            List<Sexo> listaSexos = new List<Sexo>();
            DataTable tabla = new DataTable();
            tabla = sDB.consultarTabla("Sexos");
            foreach (DataRow row in tabla.Rows)
            {
                listaSexos.Add(MappingSexo(row));
            }

            return listaSexos;
        }

        private Sexo MappingSexo(DataRow row)
        {
            Sexo oSexo = new Sexo
            {
                CodSexo = Convert.ToInt32(row["codSexo"].ToString()),
                Nombre = row["nombre"].ToString()
            };

            return oSexo;
        }
    }
}
