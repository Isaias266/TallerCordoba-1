using System;
using System.Collections.Generic;
using TallerAutos.DataAccessLayer;
using TallerAutos.Entities;

namespace TallerAutos.BusinessLayer
{
    class RolService
    {
        private RolDao oRolDao = new RolDao();
        public IList<Rol> RecuperarRoles()
        {
            return oRolDao.RecuperarRoles();
        }
    }
}
