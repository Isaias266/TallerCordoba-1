using System.Collections.Generic;
using TallerAutos.DataAccessLayer;

namespace TallerAutos.BusinessLayer
{
    class OrdenTrabajoService
    {
        private OrdenTrabajoDao oOTDao = new OrdenTrabajoDao();

        public IList<OrdenTrabajo> consultarOT(string condiciones)
        {
            return oOTDao.consultarOT(condiciones);
        }
    } 
}
