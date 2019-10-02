using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallerAutos.DataAccessLayer;
using TallerAutos.Entities;

namespace TallerAutos.BusinessLayer
{
    class MarcaService
    {
        private MarcaDao oMarcaDao = new MarcaDao();
        public IList<Marca> recuperarMarcas()
        {
            return oMarcaDao.recuperarMarcas();
        }
    }
}
