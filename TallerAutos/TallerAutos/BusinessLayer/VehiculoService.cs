using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallerAutos.DataAccessLayer;
using TallerAutos.Entities;

namespace TallerAutos.BusinessLayer
{
    class VehiculoService
    {
        VehiculoDao oVehiculoDao = new VehiculoDao();
        public IList<Vehiculo> consultarVehiculos(string condicionesSql)
        {
            return oVehiculoDao.consultarVehiculos(condicionesSql);
        }


        public void cargarVehiculo(Vehiculo v)
        {
            oVehiculoDao.cargarVehiculo(v);
        }

        public void actualizarVehiculo(Vehiculo v)
        {
            oVehiculoDao.actualizarVehiculo(v);
        }

        public void eliminarVehiculo(Vehiculo v)
        {
            oVehiculoDao.eliminarVehiculo(v);
        }
    }
}
