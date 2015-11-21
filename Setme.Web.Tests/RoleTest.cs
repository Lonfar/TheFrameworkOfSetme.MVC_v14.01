using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Setme.Domain.Model;
using Setme.Domain.Service;

namespace Setme.Web.Tests
{
    [TestClass]
    public class RoleTest
    {
        [TestMethod]
        public void TestCreateRole()
        {
            var role = Role.CreateRole("Administrator", "System Administrator");
            IRoleService roleService = new RoleService();
            roleService.CreateRole(role);
        }
    }
}
