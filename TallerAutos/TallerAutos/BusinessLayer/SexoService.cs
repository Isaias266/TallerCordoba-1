using System.Collections.Generic;
using TallerAutos.DataAccessLayer;
using TallerAutos.Entities;

namespace TallerAutos.BusinessLayer
{
    class SexoService
    {
        private SexoDao oSexoDao = new SexoDao();

        public IList<Sexo> RecuperarSexos()
        {
            return oSexoDao.RecuperarSexos();
        }
    }
}
