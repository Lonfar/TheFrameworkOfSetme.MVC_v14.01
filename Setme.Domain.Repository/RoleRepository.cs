using Setme.Domain.Model;
using Setme.Domain.UnitOfWork;

namespace Setme.Domain.Repository
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(IUnitOfWork _unitofwork)
            : base(_unitofwork)
        {

        }
    }
}
