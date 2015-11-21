using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setme.Infrastructure
{
/// <summary>
    /// 密码接口
/// </summary>
    public interface ICryptography
    {
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="obj">值</param>
        /// <returns></returns>
        OperationResult Encryption(Object obj);
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="obj">值</param>
        /// <returns></returns>
        OperationResult Decrypt(Object obj);
    }
}
