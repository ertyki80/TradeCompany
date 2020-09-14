using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    interface IRoleService
    {
        Role GetRole(int id);
        IEnumerable<Role> GetAllRole();
        void Create(Role role);
        void Update(int id, Role role);
        void Delete(int id);

    }
}
