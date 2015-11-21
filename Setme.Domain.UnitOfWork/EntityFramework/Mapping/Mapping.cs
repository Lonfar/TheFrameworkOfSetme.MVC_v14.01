using System.Data.Entity.ModelConfiguration;

namespace Setme.Domain.UnitOfWork.EntityFramework.Mapping
{
    /// <summary>
    /// 映射对象类
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class Mapping<TEntity> : EntityTypeConfiguration<TEntity>, IMapping where TEntity : class/*,IAggregateRoot*/
    {
        public void RegistTo(System.Data.Entity.ModelConfiguration.Configuration.ConfigurationRegistrar configurationRegistrar)
        {
            configurationRegistrar.Add(this);
        }
    }
}
