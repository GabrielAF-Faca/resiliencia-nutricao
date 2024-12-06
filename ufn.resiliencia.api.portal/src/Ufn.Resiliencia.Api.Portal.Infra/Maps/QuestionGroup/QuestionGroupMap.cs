using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Ufn.Resiliencia.Api.Portal.Infra.Maps.Shared;

using QuestionGroupDomain = Ufn.Resiliencia.Api.Portal.Domain.Entities.QuestionGroup;

namespace Ufn.Resiliencia.Api.Portal.Infra.Maps.QuestionGroup;
public class QuestionGroupMap : EntityMap<QuestionGroupDomain>
{
    public override void Configure(EntityTypeBuilder<QuestionGroupDomain> builder)
    {
        builder.Property(b => b.IdQuestionnaire)
            .IsRequired()
            .HasColumnName("id_questionnaire");
        builder.Property(b => b.Description)
            .HasColumnName("description");
        builder.Property(b => b.QuestionGroupOrder)
            .HasColumnName("question_group_order");
        builder.Property(b => b.Active)
            .HasColumnName("active");

        builder.HasMany(b => b.Questions)
            .WithOne(b => b.QuestionGroup)
            .HasForeignKey(b => b.IdQuestionGroup)
            .IsRequired(true);

        builder.ToTable("question_groups");

        base.Configure(builder);
    }
}
