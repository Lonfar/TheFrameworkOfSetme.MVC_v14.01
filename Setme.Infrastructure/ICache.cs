using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setme.Infrastructure
{
/// <summary>
    /// 缓存类接口
/// </summary>
    public interface ICache
    {
        /// <summary>
        /// 得到缓存
        /// </summary>
        /// <param name="KeyId">键</param>
        /// <returns></returns>
        OperationResult GetCache(string KeyId);
        /// <summary>
        /// 存入缓存
        /// </summary>
        /// <param name="KeyId">键</param>
        /// <param name="obj">值</param>
        /// <param name="timespan">过期时间</param>
        /// <returns></returns>
        OperationResult SetCache(string KeyId, Object obj, TimeSpan timespan);
        /// <summary>
        /// 删除指定缓存
        /// </summary>
        /// <param name="KeyId">键</param>
        /// <returns></returns>
        OperationResult RemoveCache(string KeyId);

    }
}
