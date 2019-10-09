using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using TallerAutos.DataAccessLayer;
using TallerAutos.Entities;

namespace TallerAutos.BusinessLayer
{
    class EstadoService
    {
        BaseDeDatos eDB = new BaseDeDatos();

        public IList<Estado> RecuperarEstados()
        {
            EstadoDao oEstadoDao = new EstadoDao();
            return oEstadoDao.RecuperarEstados();
        }
    }
}
