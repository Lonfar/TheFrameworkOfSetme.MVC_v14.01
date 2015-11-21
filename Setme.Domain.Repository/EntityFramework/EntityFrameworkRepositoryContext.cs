using Setme.Domain.UnitOfWork;
using System.Data.Entity;
using System.Linq;
using System.Threading;

namespace Setme.Domain.Repository.EntityFramework
{
    public class EntityFrameworkRepositoryContext : IUnitOfWorkContext
    {
        private ThreadLocal<EFDbContext> localEFDbContext = new ThreadLocal<EFDbContext>(() => new EFDbContext());

        public bool IsCommited
        {
            get;
            set;
        }

        public int Commit()
        {
            int count = 0;
            if (!IsCommited)
            {
                count = localEFDbContext.Value.SaveChanges();
                IsCommited = true;
            }
            return count;
        }

        public void Rollback()
        {
            foreach (var item in localEFDbContext.Value.GetValidationErrors())
            {
                if (item.Entry.State != EntityState.Detached)
                {
                    item.Entry.State = EntityState.Detached;
                }
            }
            IsCommited = false;
        }

        public void Dispose()
        {
            localEFDbContext.Dispose();
        }

        public void RegisterCreate(IAggregateRoot aggre)
        {
            localEFDbContext.Value.Entry(aggre).State = EntityState.Added;
            IsCommited = false;
        }

        public void RegisterDeleted(IAggregateRoot aggre)
        {
            localEFDbContext.Value.Entry(aggre).State = EntityState.Deleted;
            IsCommited = false;
        }

        public void RegisterUpdate(IAggregateRoot aggre)
        {
            localEFDbContext.Value.Entry(aggre).State = EntityState.Modified;
            IsCommited = false;
        }

        public IQueryable<TEntity> GetEntity<TEntity>() where TEntity : class,IAggregateRoot
        {
            return localEFDbContext.Value.Set<TEntity>();
        }
    }
}
