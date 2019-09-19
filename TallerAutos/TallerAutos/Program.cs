using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TallerAutos.GUILayer;

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
            bool DEBUG = false;


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmEmpleados());
            if(DEBUG)
                Application.Run(new frmMenuPrincipal());
            else
                Application.Run(new frmLogin());
        }
    }
}
