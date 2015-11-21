using Setme.Domain.UnitOfWork;
using System.Linq;

namespace Setme.Domain.Repository
{
    /// <summary>
    /// EntityFramework仓储基类
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IAggregateRoot
    {
        public Repository(IUnitOfWork _unitofwork)
        {
            if (_unitofwork is IUnitOfWork)
            {
                unitofworkContext = (IUnitOfWorkContext)_unitofwork;
            }
        }

        private readonly IUnitOfWorkContext unitofworkContext;

        public void Insert(IAggregateRoot aggre)
        {
            unitofworkContext.RegisterCreate(aggre);
        }

        public void Delete(IAggregateRoot aggre)
        {
            unitofworkContext.RegisterDeleted(aggre);
        }

        public void Update(IAggregateRoot aggre)
        {
            unitofworkContext.RegisterUpdate(aggre);
        }

        public IQueryable<TEntity> GetEntity
        {
            get { return unitofworkContext.GetEntity<TEntity>(); }
        }
    }
}
