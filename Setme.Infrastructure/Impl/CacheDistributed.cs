using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setme.Infrastructure.Impl
{
    /// <summary>
    /// 缓存接口实现类,分布式缓存
    /// </summary>
    public class CacheDistributed : ICache
    {

        public OperationResult GetCache(string KeyId)
        {
            throw new NotImplementedException();
        }

        public OperationResult SetCache(string KeyId, object obj, TimeSpan timespan)
        {
            throw new NotImplementedException();
        }

        public OperationResult RemoveCache(string KeyId)
        {
            throw new NotImplementedException();
        }
    }
}
