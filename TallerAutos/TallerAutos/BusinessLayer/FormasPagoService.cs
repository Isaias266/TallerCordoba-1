using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallerAutos.DataAccessLayer;
using TallerAutos.Entities;
using System.Data;

namespace TallerAutos.BusinessLayer
{
    public class FormasPagoService
    {
        BaseDeDatos fDB = new BaseDeDatos();

        public IList<FormaPago> RecuperarFormasPago()
        {
            FormaPagoDao oFormaPagoDao = new FormaPagoDao();
            return oFormaPagoDao.RecuperarFormasPago();
        }
    }
}
