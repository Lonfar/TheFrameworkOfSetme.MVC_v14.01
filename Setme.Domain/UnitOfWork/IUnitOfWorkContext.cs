using System.Linq;

namespace Setme.Domain.UnitOfWork
{
    public interface IUnitOfWorkContext : IUnitOfWork
    {
        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="aggre"></param>
        void RegisterCreate(IAggregateRoot aggre);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="aggre"></param>
        void RegisterDeleted(IAggregateRoot aggre);
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="aggre"></param>
        void RegisterUpdate(IAggregateRoot aggre);
        /// <summary>
        /// 获取
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        IQueryable<TEntity> GetEntity<TEntity>() where TEntity : class,IAggregateRoot;
    }
}
