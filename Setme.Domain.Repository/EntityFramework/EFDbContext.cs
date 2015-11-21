using Setme.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Data.Common;
using System.Data.Entity;

namespace Setme.Domain.Repository.EntityFramework
{
    /// <summary>
    /// EntityFramework上下文
    /// </summary>
    public class EFDbContext : DbContext
    {
        public EFDbContext()
            : base("name=default")
        {

        }

        public EFDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        public EFDbContext(DbConnection existingConnection)
            : base(existingConnection, true)
        {

        }

        [ImportMany("IMapping", typeof(IMapping))]
        public IEnumerable<IMapping> m_Mappings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var catalog = new DirectoryCatalog(AppDomain.CurrentDomain.BaseDirectory);
            var container = new CompositionContainer(catalog);
            m_Mappings = container.GetExportedValues<IMapping>("IMapping");

            if (m_Mappings != null)
            {
                foreach (var mapping in m_Mappings)
                {
                    //注册
                    mapping.RegistTo(modelBuilder.Configurations);
                }
            }
            base.OnModelCreating(modelBuilder);
            //DatabaseInitializer.Initialize();
        }
    }
}
