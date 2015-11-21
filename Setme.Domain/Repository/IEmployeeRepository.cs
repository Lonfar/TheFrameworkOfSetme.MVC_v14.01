using Setme.Domain.Model;

namespace Setme.Domain.Repository
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        /// <summary>
        /// 确定指定的用户名是否存在
        /// </summary>
        /// <param name="_UserName">待确定的用户名</param>
        /// <returns>如果用户名存在，则返回true，否则返回false</returns>
        bool ExistsUserName(string _UserName);
        /// <summary>
        /// 确定指定的电子邮件地址是否存在
        /// </summary>
        /// <param name="_Email">待确定的电子邮件地址</param>
        /// <returns>如果电子邮件地址存在，则返回true，否则返回false</returns>
        bool ExistsEmail(string _Email);
        /// <summary>
        /// 验证用户名与密码是否一致
        /// </summary>
        /// <param name="_UserName">待确定的用户名</param>
        /// <param name="_PassWord">待确定的密码</param>
        /// <returns>如果两者一致，则返回true，否则返回false</returns>
        bool CheckPassWord(string _UserName, string _PassWord);
        /// <summary>
        /// 根据用户名获得实体
        /// </summary>
        /// <param name="_UserName">用户名</param>
        /// <returns>Employee实体类</returns>
        Employee GetEntityByUserName(string _UserName);
        /// <summary>
        /// 根据Email获得实体
        /// </summary>
        /// <param name="_Email">Email</param>
        /// <returns>Employee实体类</returns>
        Employee GetEntityByEmail(string _Email);

    }
}
