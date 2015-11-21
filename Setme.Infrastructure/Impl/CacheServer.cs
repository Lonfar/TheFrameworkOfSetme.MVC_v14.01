using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using System.Collections;
using System.ComponentModel;

namespace Setme.Infrastructure.Impl
{
    /// <summary>
    /// 缓存接口实现类,服务器缓存
    /// </summary>
    public class CacheServer : ICache
    {
        private ObjectCache Mycache = MemoryCache.Default;
        private CacheItem item = null;
        private CacheItemPolicy policy = null;
        public OperationResult GetCache(string KeyId)
        {
            if (KeyId != null || KeyId != "")
            {
                item = Mycache.GetCacheItem(KeyId);
                if (item.Equals(null))
                {
                    return new OperationResult(OperationResultType.Success, string.Format("成功取得{0}缓存值", KeyId), item.Value);
                }
                return new OperationResult(OperationResultType.QueryNull, string.Format("键{0}的缓存为空", KeyId));
            }
            return new OperationResult(OperationResultType.ParamError, "KeyId is null");
        }
        public OperationResult SetCache(string KeyId, object obj, TimeSpan timespan)
        {
            if (KeyId != null || KeyId != "")
            {
                item = Mycache.GetCacheItem(KeyId);
                if (item.Equals(null))
                {
                    item = new CacheItem(KeyId, obj);
                    policy.AbsoluteExpiration.Add(timespan);
                    Mycache.Set(item, policy);
                    return new OperationResult(OperationResultType.Success, string.Format("成功插入{0}缓存", KeyId));
                }
                return new OperationResult(OperationResultType.NoChanged, string.Format("已存在{0}键的缓存", KeyId));
            }
            return new OperationResult(OperationResultType.ParamError, "KeyId is null");
        }
        public OperationResult RemoveCache(string KeyId)
        {
            if (KeyId != null || KeyId != "")
            {
                try
                {
                    Mycache.Remove(KeyId);
                    return new OperationResult(OperationResultType.Success, string.Format("成功删除{0}缓存", KeyId));
                }
                catch (Exception ex)
                {
                    return new OperationResult(OperationResultType.Error, string.Format("Error: \n{0}", ex.Message));
                }
            }
            return new OperationResult(OperationResultType.ParamError, "KeyId is null");
        }
    }
}
