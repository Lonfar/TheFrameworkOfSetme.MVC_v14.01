using System;

namespace Setme.Domain
{
    /// <summary>
    /// 表示 领域实体类 接口
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// 获取当前领域实体类的 全局唯一标识。
        /// </summary>
        Guid id { get; }

        /// <summary>
        ///     获取或设置 时间戳
        /// </summary>
        Byte[] TimeStamp { get; set; }
    }
}
