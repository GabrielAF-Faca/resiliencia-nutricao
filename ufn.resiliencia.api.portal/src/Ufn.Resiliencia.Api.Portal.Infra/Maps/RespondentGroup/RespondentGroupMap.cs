using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Ufn.Resiliencia.Api.Portal.Infra.Maps.Shared;

using RespondentGroupDomain = Ufn.Resiliencia.Api.Portal.Domain.Entities.RespondentGroup;

namespace Ufn.Resiliencia.Api.Portal.Infra.Maps.RespondentGroup;
public class RespondentGroupMap : EntityMap<RespondentGroupDomain>
{
    public override void Configure(EntityTypeBuilder<RespondentGroupDomain> builder)
    {
        builder.Property(b => b.Description)
            .HasColumnName("description");
        builder.Property(b => b.Active)
            .HasColumnName("active");

        builder.ToTable("respondent_groups");

        base.Configure(builder);
    }
}
