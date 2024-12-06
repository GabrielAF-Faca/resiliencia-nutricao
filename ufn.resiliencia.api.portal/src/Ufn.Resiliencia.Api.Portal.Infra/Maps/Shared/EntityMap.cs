using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Ufn.Resiliencia.Api.Portal.Domain.Entities.Shared;

namespace Ufn.Resiliencia.Api.Portal.Infra.Maps.Shared;

public class EntityMap<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id)
            .IsRequired()
            .HasColumnName("id");
    }
}
