using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallerAutos.Entities;
using TallerAutos.DataAccessLayer;

namespace TallerAutos.BusinessLayer
{
    class ClienteService
    {
        ClienteDao clienteDao = new ClienteDao();

        public IList<Cliente> ConsultarClientes(string strConsulta)
        {
            return clienteDao.consultarClientes(strConsulta);
        }

    }
}
