using Setme.Domain.Repository;
using Setme.Domain.UnitOfWork;
using Setme.Domain.UnitOfWork.EntityFramework;
using Setme.Infrastructure;
using System;
using System.Linq;

namespace Setme.Domain.Service
{
    public class EmployeeService : IEmployeeService
    {
        public OperationResult CreateEmployee(Model.Employee model)
        {
            using (IUnitOfWork unitofwork = new EntityFrameworkContext())
            {
                IEmployeeRepository employeeRepository = new EmployeeRepository(unitofwork);
                if (!employeeRepository.ExistsUserName(model.UserName))
                {
                    employeeRepository.Insert(model);
                    unitofwork.Commit();
                    return new OperationResult(OperationResultType.Success, "用户注册成功.");
                }
                return new OperationResult(OperationResultType.NoChanged, "用户名已存在.");
            }
        }

        public OperationResult ChangeEmployee(Model.Employee model)
        {
            using (IUnitOfWork unitofwork = new EntityFrameworkContext())
            {
                IEmployeeRepository employeeRepository = new EmployeeRepository(unitofwork);
                var employee = employeeRepository.GetEntity.Where(m => m.UserName == model.UserName || m.Email == model.Email).FirstOrDefault();
                employee.RealName = model.RealName;
                employeeRepository.Update(employee);
                int count = unitofwork.Commit();
                return new OperationResult(OperationResultType.Success, count.ToString());
            }
        }
    }
}
