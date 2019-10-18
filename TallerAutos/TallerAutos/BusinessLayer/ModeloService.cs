using System;
using System.Collections.Generic;
using TallerAutos.Entities;
using TallerAutos.DataAccessLayer;

namespace TallerAutos.BusinessLayer
{
    class ModeloService
    {
        private ModeloDao oModeloDao = new ModeloDao();
        public IList<Modelo> RecuperarModelos()
        {
            return oModeloDao.RecuperarModelos();
        }

        public IList<Modelo> ConsultarModelos(String sqlString)
        {
            return oModeloDao.ConsultarModelos(sqlString);
        }


    }
}
