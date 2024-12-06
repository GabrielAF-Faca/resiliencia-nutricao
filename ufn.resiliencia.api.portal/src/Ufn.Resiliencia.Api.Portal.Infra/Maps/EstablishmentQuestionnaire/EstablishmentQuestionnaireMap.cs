using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Ufn.Resiliencia.Api.Portal.Infra.Maps.Shared;

using EstablishmentQuestionnaireDomain = Ufn.Resiliencia.Api.Portal.Domain.Entities.EstablishmentQuestionnaire;

namespace Ufn.Resiliencia.Api.Portal.Infra.Maps.EstablishmentQuestionnaire;
public class EstablishmentQuestionnaireMap : EntityMap<EstablishmentQuestionnaireDomain>
{
    public override void Configure(EntityTypeBuilder<EstablishmentQuestionnaireDomain> builder)
    {
        builder.Property(b => b.IdEstablishment)
            .HasColumnName("id_establishment");
        builder.Property(b => b.IdQuestionnaire)
            .HasColumnName("id_questionnaire");
        builder.Property(b => b.Active)
            .HasColumnName("active");

        builder.ToTable("establishment_questionnaires");

        base.Configure(builder);
    }
}
