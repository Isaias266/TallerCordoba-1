using System.Collections.Generic;
using TallerAutos.DataAccessLayer;

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
