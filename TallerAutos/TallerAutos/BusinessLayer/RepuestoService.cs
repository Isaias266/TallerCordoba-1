using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallerAutos.DataAccessLayer;
using TallerAutos.Entities;

namespace TallerAutos.BusinessLayer
{
    class RepuestoService
    {
        RepuestoDao repuestoDao = new RepuestoDao();

        public IList<Repuesto> ConsultarRepuestos(string strConsulta)
        {
            return repuestoDao.ConsultarRepuestos(strConsulta);
        }

        public void CargarRepuesto(Repuesto r)
        {
            repuestoDao.CargarRepuesto(r);
        }

        public void ActualizarRepuesto(Repuesto r)
        {
            repuestoDao.ActualizarRepuesto(r);
        }

        public void EliminarRepuesto(Repuesto r)
        {
            repuestoDao.EliminarRepuesto(r);
        }
    }
}
