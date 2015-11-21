using Setme.Domain.Model;
using System;
using System.Linq;

namespace Setme.Domain.Repository
{
    /// <summary>
    /// 仓储基类接口
    /// </summary>
    /// <separatism name="TEntity">聚合根</typeparam>
    public interface IRepository<TEntity> where TEntity : class,IAggregateRoot
    {
        /// <summary>
        /// 添加实体数据
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        void Insert(IAggregateRoot aggre);

        /// <summary>
        /// 删除实体数据
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        void Delete(IAggregateRoot aggre);

        /// <summary>
        /// 更新实体数据
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        void Update(IAggregateRoot aggre);
        /// <summary>
        /// 获取
        /// </summary>
        IQueryable<TEntity> GetEntity { get; }
    }
}
