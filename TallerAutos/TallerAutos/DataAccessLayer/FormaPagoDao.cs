using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallerAutos.Entities;
using System.Data;

namespace TallerAutos.DataAccessLayer
{
    class FormaPagoDao
    {
        BaseDeDatos fDB = new BaseDeDatos();

        public List<FormaPago> RecuperarFormasPago()
        {
            List<FormaPago> listaFormas = new List<FormaPago>();
            DataTable tabla = new DataTable();
            tabla = fDB.ConsultarTabla("FormasPago");
            foreach (DataRow row in tabla.Rows)
            {
                listaFormas.Add(MappingFormasPago(row));
            }

            return listaFormas;
        }

        private FormaPago MappingFormasPago(DataRow row)
        {
            FormaPago oFormaPago = new FormaPago();

            oFormaPago.CodFormaPago = Convert.ToInt32(row["codFormaPago"].ToString());
            oFormaPago.Nombre = row["nombre"].ToString();
           

            return oFormaPago;
        }
    }
}
