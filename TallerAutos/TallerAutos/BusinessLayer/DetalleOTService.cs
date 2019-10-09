using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallerAutos.DataAccessLayer;
using TallerAutos.Entities;

namespace TallerAutos.BusinessLayer
{
    public class DetalleOTService
    {
        DetalleOTDao oDetalleOTDao = new DetalleOTDao();

        public IList<DetalleOT> ConsultarDetalles(string condicionesSql)
        {
            return oDetalleOTDao.ConsultarDetalles(condicionesSql);
        }
    }
}
