using Setme.Domain.Model;
using Setme.Domain.UnitOfWork;

namespace Setme.Domain.Repository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IUnitOfWork _unitofwork)
            : base(_unitofwork)
        {

        }

        public bool ExistsUserName(string _UserName)
        {
            throw new System.NotImplementedException();
        }

        public bool ExistsEmail(string _Email)
        {
            throw new System.NotImplementedException();
        }

        public bool CheckPassWord(string _UserName, string _PassWord)
        {
            throw new System.NotImplementedException();
        }

        public Employee GetEntityByUserName(string _UserName)
        {
            throw new System.NotImplementedException();
        }

        public Employee GetEntityByEmail(string _Email)
        {
            throw new System.NotImplementedException();
        }
    }
}
