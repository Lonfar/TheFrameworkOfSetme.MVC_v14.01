using System;
using Setme.Domain.Model;
using Setme.Domain.Service;

namespace Test
{
    
    public class RoleTest
    {
        
        public void TestCreateRole()
        {
            var role = Role.CreateRole("Administrator", "System Administrator");
            IRoleService roleService = new Setme.Domain.Service.RoleService();
            roleService.CreateRole(role);
        }
    }
}
