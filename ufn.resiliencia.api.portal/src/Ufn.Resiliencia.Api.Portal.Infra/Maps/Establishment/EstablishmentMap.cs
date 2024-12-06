using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Ufn.Resiliencia.Api.Portal.Infra.Maps.Shared;

using EstablishmentDomain = Ufn.Resiliencia.Api.Portal.Domain.Entities.Establishment;

namespace Ufn.Resiliencia.Api.Portal.Infra.Maps.Establishment;
public class EstablishmentMap : EntityMap<EstablishmentDomain>
{
    public override void Configure(EntityTypeBuilder<EstablishmentDomain> builder)
    {
        builder.Property(b => b.Name)
            .HasColumnName("name");
        builder.Property(b => b.ZipCode)
            .HasColumnName("zip_code");
        builder.Property(b => b.Street)
            .HasColumnName("street");
        builder.Property(b => b.Neighborhood)
            .HasColumnName("neighborhood");
        builder.Property(b => b.City)
            .HasColumnName("city");
        builder.Property(b => b.State)
            .HasColumnName("state");
        builder.Property(b => b.Number)
            .HasColumnName("number");
        builder.Property(b => b.Complement)
            .HasColumnName("complement");
        builder.Property(b => b.Active)
            .HasColumnName("active");

        builder.ToTable("establishments");

        base.Configure(builder);
    }
}
