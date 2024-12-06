using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Ufn.Resiliencia.Api.Portal.Infra.Maps.Shared;

using QuestionnaireDomain = Ufn.Resiliencia.Api.Portal.Domain.Entities.Questionnaire;

namespace Ufn.Resiliencia.Api.Portal.Infra.Maps.Questionnaire;
public class QuestionnaireMap : EntityMap<QuestionnaireDomain>
{
    public override void Configure(EntityTypeBuilder<QuestionnaireDomain> builder)
    {
        builder.Property(b => b.IdRespondentGroup)
            .IsRequired()
            .HasColumnName("id_respondent_group");
        builder.Property(b => b.Description)
            .IsRequired()
            .HasColumnName("description");
        builder.Property(b => b.Active)
            .IsRequired()
            .HasColumnName("active");

        builder.HasMany(b => b.QuestionGroups)
            .WithOne(b => b.Questionnaire)
            .HasForeignKey(b => b.IdQuestionnaire)
            .IsRequired(true);

        builder.ToTable("questionnaires");

        base.Configure(builder);
    }
}
