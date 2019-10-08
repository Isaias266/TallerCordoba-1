using System;
using TallerAutos.DataAccessLayer;
using TallerAutos.Entities;
using System.Collections.Generic;

namespace TallerAutos.BusinessLayer
{
    class EmpleadoService
    {
        EmpleadoDao oEmpleadoDao = new EmpleadoDao();

        public Empleado ValidarEmpleado(string us, string pa)
        {
            var usr = oEmpleadoDao.ValidarEmpleado(us, pa);
            if (usr != null)
            {
                return usr;
            }
            return null;
        }

        public IList<Empleado> ConsultarEmpleados(string condicionesSql)
        {
            return oEmpleadoDao.ConsultarEmpleados(condicionesSql);
        }


        public void CargarEmpleado(Empleado e)
        {
            oEmpleadoDao.CargarEmpleado(e);
        }

        public void ActualizarEmpleado(Empleado e)
        {
            oEmpleadoDao.ActualizarEmpleado(e);
        }

        public void EliminarEmpleado(Empleado e)
        {
            oEmpleadoDao.EliminarEmpleado(e);
        }

        public bool ValidarUserEmpleado(string user)
        {
            return oEmpleadoDao.ValidarUserEmpleado(user);
        }
    }
}
