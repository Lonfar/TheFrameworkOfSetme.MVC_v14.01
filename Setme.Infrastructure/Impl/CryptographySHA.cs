using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Setme.Infrastructure.Impl
{
    /// <summary>
    /// 密码接口实现类,SHA-2即SHA512
    /// </summary>
    public class CryptographySHA : ICryptography
    {
        public OperationResult Encryption(object obj)
        {
            try
            {
                byte[] data = new byte[(int)obj];
                byte[] result;
                SHA512 shaM = new SHA512Managed();
                result = shaM.ComputeHash(data);
                return new OperationResult(OperationResultType.Success, "SHA-2加密成功", result);
            }
            catch (Exception ex)
            {
                return new OperationResult(OperationResultType.Error, string.Format("Error: \n{0}", ex.Message));
            }
        }

        public OperationResult Decrypt(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
