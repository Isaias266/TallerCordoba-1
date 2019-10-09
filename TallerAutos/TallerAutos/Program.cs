using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TallerAutos.GUILayer;
using TallerAutos.Entities;

namespace TallerAutos
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // VARIABLE DEBUG PARA SALTEAR LOGIN AL EJECUTAR Y FACILITAR PRUEBAS
            //No se utiliza por el momento.
            bool DEBUG = false;


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmEmpleados());
            if (DEBUG)
            {
                
                Empleado oEmpleadoDebug = new Empleado();
                oEmpleadoDebug.Nombre = "Test";
                oEmpleadoDebug.Apellido = "Test";
                Rol rol = new Rol();
                rol.CodRol = 1;
                oEmpleadoDebug.Rol = rol;
                Sexo sexo = new Sexo();
                sexo.CodSexo = 1;
                oEmpleadoDebug.Sexo = sexo;
                
                Application.Run(new frmMenuPrincipal(oEmpleadoDebug));
            }
            else
                Application.Run(new frmLogin());
        }
    }
}
