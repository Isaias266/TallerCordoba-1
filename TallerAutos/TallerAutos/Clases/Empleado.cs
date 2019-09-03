using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace TallerAutos.Clases
{
    class Empleado
    {
        private int legajo;
        private int rol;
        private string nombre;
        private string apellido;
        private string domicilio;
        private string telefono;
        private string celular;
        private DateTime fechaNacim;
        private DateTime fechaAlta;
        private int sexo;
        private string usuario;
        private string password;

        public int Legajo { get => legajo; set => legajo = value; }
        public int Rol { get => rol; set => rol = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Domicilio { get => domicilio; set => domicilio = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Celular { get => celular; set => celular = value; }
        public DateTime FechaNacim { get => fechaNacim; set => fechaNacim = value; }
        public DateTime FechaAlta { get => fechaAlta; set => fechaAlta = value; }
        public int Sexo { get => sexo; set => sexo = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Password { get => password; set => password = value; }

        BaseDeDatos eBD = new BaseDeDatos();
    
        public int validarUsuario(string us,string pa)
        {
            string consultaSQL = "SELECT * FROM Empleados WHERE usuario='" + us + "' AND password='" + pa + "'";
            BaseDeDatos eBD = new BaseDeDatos();
            DataTable tabla = eBD.consultar(consultaSQL);
            if (tabla.Rows.Count > 0)
                return (Convert.ToInt32(tabla.Rows[0][0]));
            else
                return 0;
        }

        public void cargarEmpleado()
        {
             
            string insercionSQL = "INSERT INTO Empleados (rol, nombre, apellido, domicilio, telefono, celular, fechaNacim, fechaAlta, codSexo, usuario, password) " +
                                "VALUES ('" + this.rol + "','" + this.nombre + "','" + this.apellido + "','" + this.domicilio + "','" + this.telefono +
                                "','" + this.celular +  "','" + this.fechaNacim + "','" + this.fechaAlta +"','" + this.sexo + "','" + this.usuario + "','" + this.password + "')";
            eBD.insertar(insercionSQL);
        }

        public void actualizarEmpleado()
        {
             
            string actualizacionSQL = "UPDATE Empleados SET rol=" + this.rol + ", nombre='" + this.nombre +
                                    "',apellido='" + this.apellido + "',domicilio='" + this.domicilio + 
                                    "',telefono='" + this.telefono+ "',celular='" + this.celular + "',fechaNacim='" + this.fechaNacim +
                                    "',fechaAlta='" + this.fechaAlta + "',codSexo=" + this.sexo + 
                                    ",usuario='" + this.usuario + "',password='" + this.password + "'" +
                                    " WHERE legajo= " + this.legajo;
             
            eBD.insertar(actualizacionSQL);
        }

        public DataTable obtenerEmpleados()
        {
            DataTable tabla_empleados;
            tabla_empleados = eBD.consultarTabla("Empleados");
            return tabla_empleados;
        }

       
        public void eliminarEmpleado()
        {
            string eliminacionSQL = "DELETE FROM Empleados WHERE legajo = " + this.legajo;
            eBD.insertar(eliminacionSQL);
        }

    }
}
