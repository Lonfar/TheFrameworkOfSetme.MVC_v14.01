using Setme.Domain.Model;
using Setme.Domain.Service;
using Setme.Infrastructure;
using System;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            //byte[] fileData = File.ReadAllBytes(@"E:\Git\TheFrameworkOfSetme.MVC_v14.01\Setme.Domain\bin\Debug\Setme.Domain.dll");
            //Assembly assembly = Assembly.Load(fileData);
            //IEnumerable<Type> modelTypes = assembly.DefinedTypes.Where(t => t.Namespace == "Setme.Domain.Model" && t.BaseType.Name.Equals(typeof(AggregateRoot).UnderlyingSystemType.Name)).ToList();

            Employee employee = new Employee()
            {
                Email = "38020739@qq.com",
                PassWord = "321677",
                Phone = "18622886487",
                RealName = "冯龙发",
                Sex = Setme.Domain.Model.EnumStatus.SexStatus.Man,
                UserName = "flf32167"
            };
            IEmployeeService employeeService = new EmployeeService();
            OperationResult result = employeeService.CreateEmployee(employee);
            if (result.ResultType == OperationResultType.Success)
            {
                Console.Write(result.Message);
                Console.ReadKey(true);
            }
            else
            {
                Console.Write(result.Message);
                Console.ReadKey(true);
            }
        }
    }
}
