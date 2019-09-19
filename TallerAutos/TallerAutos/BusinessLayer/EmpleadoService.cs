using System;
using TallerAutos.DataAccessLayer;
using System.Data;
using TallerAutos.Entities;
using System.Collections.Generic;

namespace TallerAutos.BusinessLayer
{
    class EmpleadoService
    {
        EmpleadoDao oEmpleadoDao = new EmpleadoDao();

        public Empleado validarEmpleado(string us, string pa)
        {
            var usr = oEmpleadoDao.validarEmpleado(us, pa);
            if (usr != null)
            {
                return usr;
            }
            return null;
        }

        public IList<Empleado> consultarEmpleados(string condicionesSql)
        {
            return oEmpleadoDao.consultarEmpleados(condicionesSql);
        }

        public void cargarEmpleado(Empleado e)
        {
            oEmpleadoDao.cargarEmpleado(e);
        }

        public void actualizarEmpleado(Empleado e)
        {
            oEmpleadoDao.actualizarEmpleado(e);
        }

        public void eliminarEmpleado(Empleado e)
        {
            oEmpleadoDao.eliminarEmpleado(e);
        }
    }
}
