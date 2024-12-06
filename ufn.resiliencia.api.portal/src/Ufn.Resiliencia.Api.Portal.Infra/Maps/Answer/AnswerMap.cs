using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Ufn.Resiliencia.Api.Portal.Infra.Maps.Shared;

using AnswerDomain = Ufn.Resiliencia.Api.Portal.Domain.Entities.Answer;

namespace Ufn.Resiliencia.Api.Portal.Infra.Maps.Answer;
public class AnswerMap : EntityMap<AnswerDomain>
{
    public override void Configure(EntityTypeBuilder<AnswerDomain> builder)
    {
        builder.Property(b => b.IdEstablishment)
            .HasColumnName("id_establishment");
        builder.Property(b => b.IdQuestion)
            .HasColumnName("id_question");
        builder.Property(b => b.UniqueCode)
            .HasColumnName("unique_code");
        builder.Property(b => b.QuestionOneAnswered)
            .HasColumnName("question_one_answered");
        builder.Property(b => b.QuestionTwoAnswered)
            .HasColumnName("question_two_answered");
        builder.Property(b => b.QuestionThreeAnswered)
            .HasColumnName("question_three_answered");
        builder.Property(b => b.AdditionalQuestionAnswered)
            .HasColumnName("additional_question_answered");

        builder.ToTable("answers");

        base.Configure(builder);
    }
}
