using System;
using System.Collections.Generic;
using TallerAutos.DataAccessLayer;
using TallerAutos.Entities;

namespace TallerAutos.BusinessLayer
{
    class OrdenTrabajoService
    {
        private OrdenTrabajoDao oOTDao = new OrdenTrabajoDao();


        public void EliminarOT(OrdenTrabajo ot)
        {
            oOTDao.EliminarOT(ot);
        }
        public IList<OrdenTrabajo> ConsultarOT(string condiciones)
        {
            return oOTDao.ConsultarOT(condiciones);
        }


        public bool Update(OrdenTrabajo oOT, int indice)
        {
            return oOTDao.Update(oOT, indice);
        }
        public bool Crear(OrdenTrabajo oOT)
        {
            return oOTDao.Crear(oOT);
        }
    } 
}
