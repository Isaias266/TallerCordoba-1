using System.Collections.Generic;
using TallerAutos.DataAccessLayer;

namespace TallerAutos.BusinessLayer
{
    class OrdenTrabajoService
    {
        private OrdenTrabajoDao oOTDao = new OrdenTrabajoDao();

        public IList<OrdenTrabajo> ConsultarOT(string condiciones)
        {
            return oOTDao.ConsultarOT(condiciones);
        }
    } 
}
