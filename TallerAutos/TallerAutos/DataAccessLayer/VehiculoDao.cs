using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallerAutos.Entities;
using System.Data;
using System.Windows.Forms;

namespace TallerAutos.DataAccessLayer
{
    class VehiculoDao
    {
        BaseDeDatos vDB = new BaseDeDatos();

        public void cargarVehiculo(Vehiculo v)
        {
            
            string insercionSQL = "INSERT INTO Vehiculos (patente, dni, codMarca, codModelo) " +
                                  "VALUES ('" + v.Patente + "'," + v.Cliente.Dni + "," + v.Marca.CodMarca +
                                  "," + v.Modelo.CodModelo + ")";
           
            vDB.insertar(insercionSQL);
        }

        public void actualizarVehiculo(Vehiculo v)
        {
            string actualizacionSQL = "UPDATE Vehiculos " +
                                         "SET patente=" + v.Patente + ", " +
                                         "dni='" + v.Cliente.Dni + "', " +
                                         "codMarca='" + v.Marca.CodMarca + "', " +
                                         "codModelo='" + v.Modelo.CodModelo + "', " +                                  
                                         "WHERE patente=" + v.Patente;
            vDB.insertar(actualizacionSQL);
        }

        public IList<Vehiculo> consultarVehiculos(string condicionesSql)
        {
            List<Vehiculo> listaVehiculos = new List<Vehiculo>();

            string strSql = "SELECT V.patente, " +
                                   "C.dni as dni, " +
                                   "V.codMarca, " +
                                   "M.nombre as nombreMarca, " +
                                   "V.codModelo, " +
                                   "MO.nombre as nombreModelo " +
                                   "FROM Vehiculos V JOIN Clientes C ON (V.dni = C.dni) " +
                                   "JOIN Marcas M ON (V.codMarca = M.codMarca) " +
                                   "JOIN Modelos MO ON (V.codModelo = MO.codModelo) " +
                                   "WHERE V.borrado = 0 ";

            strSql += condicionesSql;
            
            var resultadoConsulta = (DataRowCollection)vDB.consultar(strSql).Rows;

            foreach (DataRow row in resultadoConsulta)
            {
                if (!string.IsNullOrEmpty(row["patente"].ToString()))
                    listaVehiculos.Add(mappingVehiculos(row));
            }

            return listaVehiculos;
        }

        public void eliminarVehiculo(Vehiculo v)
        {
            string eliminacionSQL = "UPDATE Vehiculos SET borrado = 1 WHERE patente = " + v.Patente;
            vDB.insertar(eliminacionSQL);
        }
        private Vehiculo mappingVehiculos(DataRow row)
        {
            Vehiculo oVehiculo = new Vehiculo();


            oVehiculo.Patente = row["patente"].ToString();
            oVehiculo.Cliente = new Cliente();
            oVehiculo.Cliente.Dni = Convert.ToInt32(row["dni"].ToString());
            oVehiculo.Modelo = new Modelo();
            oVehiculo.Modelo.CodModelo = Convert.ToInt32(row["codModelo"].ToString());
            oVehiculo.Modelo.Nombre = row["nombreModelo"].ToString();
            oVehiculo.Marca = new Marca();
            oVehiculo.Marca.CodMarca = Convert.ToInt32(row["codMarca"].ToString());
            oVehiculo.Marca.Nombre = row["nombreMarca"].ToString();

            return oVehiculo;
        }
    }
}
