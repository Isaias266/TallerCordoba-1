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
        public IList<Vehiculo> ConsultarVehiculos(string condicionesSql)
        {
            return oVehiculoDao.ConsultarVehiculos(condicionesSql);
        }


        public void CargarVehiculo(Vehiculo v)
        {
            oVehiculoDao.CargarVehiculo(v);
        }

        public void ActualizarVehiculo(Vehiculo v)
        {
            oVehiculoDao.ActualizarVehiculo(v);
        }

        public void EliminarVehiculo(Vehiculo v)
        {
            oVehiculoDao.EliminarVehiculo(v);
        }
    }
}
