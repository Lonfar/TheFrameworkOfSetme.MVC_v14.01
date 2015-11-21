using Setme.Domain.UnitOfWork;
using System;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;

namespace Setme.Domain.UnitOfWork.EntityFramework
{
    public class EntityFrameworkContext : IUnitOfWorkContext
    {
        /// <summary>
        /// 注册一个本地线程存储EF上下文
        /// </summary>
        private ThreadLocal<EFDbContext> localEFDbContext = new ThreadLocal<EFDbContext>(() => new EFDbContext());

        /// <summary>
        /// 是否提交
        /// </summary>
        public bool IsCommited
        {
            get;
            set;
        }

        /// <summary>
        /// 提交
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// 回滚
        /// </summary>
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

        /// <summary>
        /// 释放
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            System.GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 析构函数（解构器）
        /// </summary>
        ~EntityFrameworkContext()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// 重写Dispose(bool)
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing && localEFDbContext != null)
            {
                localEFDbContext.Dispose();
                localEFDbContext = null;
            }
        }

        /// <summary>
        /// 登记创建
        /// </summary>
        /// <param name="aggre"></param>
        public void RegisterCreate(IAggregateRoot aggre)
        {
            localEFDbContext.Value.Entry(aggre).State = EntityState.Added;
            IsCommited = false;
        }

        /// <summary>
        /// 登记删除
        /// </summary>
        /// <param name="aggre"></param>
        public void RegisterDeleted(IAggregateRoot aggre)
        {
            localEFDbContext.Value.Entry(aggre).State = EntityState.Deleted;
            IsCommited = false;
        }

        /// <summary>
        /// 登记修改
        /// </summary>
        /// <param name="aggre"></param>
        public void RegisterUpdate(IAggregateRoot aggre)
        {
            localEFDbContext.Value.Entry(aggre).State = EntityState.Modified;
            IsCommited = false;
        }

        /// <summary>
        /// 得到实体进行查询操作
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns>返回Linq</returns>
        public IQueryable<TEntity> GetEntity<TEntity>() where TEntity : class,IAggregateRoot
        {
            return localEFDbContext.Value.Set<TEntity>();
        }
    }
}
