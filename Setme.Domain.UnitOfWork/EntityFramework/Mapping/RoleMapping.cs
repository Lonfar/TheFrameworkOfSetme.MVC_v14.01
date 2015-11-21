using Setme.Domain.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;

namespace Setme.Domain.UnitOfWork.EntityFramework.Mapping
{
    internal  class RoleMapping : Mapping<Role>
    {
        internal  RoleMapping()
        {
            this.Property(t => t.RoleName).HasColumnAnnotation
            (
                IndexAnnotation.AnnotationName,
                new IndexAnnotation
                (
                    new IndexAttribute() { IsUnique = true }
                )
            );
        }
    }
}
