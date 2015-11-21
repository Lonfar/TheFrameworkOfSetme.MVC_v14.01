using Setme.Infrastructure.Impl;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using Setme.Domain.Model;

namespace Setme.Domain.Repository.EntityFramework.Mapping
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
