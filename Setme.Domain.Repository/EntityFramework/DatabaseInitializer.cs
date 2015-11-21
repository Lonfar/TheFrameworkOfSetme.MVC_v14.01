using System.Data.Entity;

namespace Setme.Domain.Repository.EntityFramework
{
    /// <summary>
    /// 数据库初始化操作类
    /// </summary>
   public static class DatabaseInitializer
    {
        /// <summary>
        /// 数据库初始化
        /// </summary>
        public static void Initialize()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<EFDbContext>());
        }
    }
}
