using Setme.Domain.Repository;
using Setme.Domain.UnitOfWork;
using Setme.Domain.UnitOfWork.EntityFramework;
using Setme.Infrastructure;
using System;
using System.Linq;

namespace Setme.Domain.Service
{
    public class RoleService : IRoleService
    {
        public OperationResult CreateRole(Model.Role model)
        {
            using (IUnitOfWork unitofwork = new EntityFrameworkContext())
            {
                IRoleRepository roleRepository = new RoleRepository(unitofwork);
                if (roleRepository.GetEntity.Count(m => m.RoleName == model.RoleName) <= 0)
                {
                    roleRepository.Insert(model);
                    unitofwork.Commit();
                    return new OperationResult(OperationResultType.Success, "角色添加成功.");
                }
                return new OperationResult(OperationResultType.NoChanged, "角色名已存在.");
            }
        }

        public OperationResult ChangeRole(Model.Role model)
        {
            throw new NotImplementedException();
        }
    }
}
