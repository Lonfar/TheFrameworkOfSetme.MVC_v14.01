using Setme.Domain.Model;
using Setme.Infrastructure;

namespace Setme.Domain.Service
{
    public interface IEmployeeService
    {
        /// <summary>
        /// 创建实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        OperationResult CreateEmployee(Employee model);

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        OperationResult ChangeEmployee(Employee model);
    }
}
