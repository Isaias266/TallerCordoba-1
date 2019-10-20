using System;
using System.Collections.Generic;
using TallerAutos.DataAccessLayer;
using TallerAutos.Entities;

namespace TallerAutos.BusinessLayer
{
    class OrdenTrabajoService
    {
        private OrdenTrabajoDao oOTDao = new OrdenTrabajoDao();

        public IList<OrdenTrabajo> ConsultarOT(string condiciones)
        {
            return oOTDao.ConsultarOT(condiciones);
        }

        public bool Crear(OrdenTrabajo oOT)
        {
            return oOTDao.Crear(oOT);
        }
    } 
}
