using Microsoft.VisualStudio.TestTools.UnitTesting;
using Setme.Domain.Model;
using Setme.Domain.Service;

namespace Setme.Tests
{
    [TestClass]
    public class EmployeeTest
    {
        [TestMethod]
        public void TestCreateEmployee()
        {
            var employee = Employee.CreateEmployee("flf32167", "321677", "冯龙发", Domain.Model.EnumStatus.SexStatus.Man, "18622886487", "0471-xxxxxxx", "setme_1986@hotmail.com", Domain.Model.EnumStatus.OpenStatus.On);
            IEmployeeService employeeService = new EmployeeService();
            employeeService.CreateEmployee(employee);
        }
        [TestMethod]
        public void TestChangeEmployee()
        {
            var employee = new Employee();
            employee.UserName = "flf32167";
            employee.RealName = "8522";
            IEmployeeService employeeService = new EmployeeService();
            employeeService.ChangeEmployee(employee);
        }
    }
}
