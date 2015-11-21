using System;

namespace Setme.Domain.UnitOfWork
{
    /// <summary>
    /// 表示所有集成于该接口的类型都是UnitOfWork的一种实现
    /// </summary>
    /// <remarks>
    /// 有关UnitOfWork的详细信息,请参见UnitOfWork模式：http://martinfowler.com/eaaCatalog/unitOfWork.html
    /// </remarks>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// 是否提交
        /// </summary>
        bool IsCommited { get; set; }

        /// <summary>
        /// 提交当前工作单元
        /// </summary>
        int Commit();

        /// <summary>
        /// 撤销当前工作单元
        /// </summary>
        /// <returns></returns>
        void Rollback();
    }
}
