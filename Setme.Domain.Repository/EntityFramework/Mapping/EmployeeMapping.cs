using Setme.Infrastructure.Impl;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using Setme.Domain.Model;

namespace Setme.Domain.Repository.EntityFramework.Mapping
{
    internal class EmployeeMapping : Mapping<Employee>
    {
        internal  EmployeeMapping()
        {
            this.Property(t => t.UserName).HasColumnAnnotation
               (
                   IndexAnnotation.AnnotationName,
                   new IndexAnnotation
                   (
                        new IndexAttribute() { IsUnique = true }
                   )
               );
            this.HasMany(t => t.Role)
                .WithMany(t => t.Employee);
            this.Property(t => t.PassWord).HasMaxLength(50);
        }
    }
}
