using Setme.Domain.Model;
using Setme.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setme.Domain.Service
{
    public interface IRoleService
    {
        OperationResult CreateRole(Role model);
        OperationResult ChangeRole(Role model);
    }
}
