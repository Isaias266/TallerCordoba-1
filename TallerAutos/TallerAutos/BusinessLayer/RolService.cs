using System;
using System.Collections.Generic;
using TallerAutos.DataAccessLayer;

namespace TallerAutos.BusinessLayer
{
    class RolService
    {
        private RolDao oRolDao = new RolDao();
        public IList<Rol> recuperarRoles()
        {
            return oRolDao.recuperarRoles();
        }
    }
}
