using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TallerAutos.DataAccessLayer
{
    class Sexo
    {
        public int CodSexo { get; set; }
        public string Nombre { get; set; }

        /*
        public int CodSexo { get => codSexo; set => codSexo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        */

        public override string ToString()
        {
            return Nombre;
        }
    }
}
