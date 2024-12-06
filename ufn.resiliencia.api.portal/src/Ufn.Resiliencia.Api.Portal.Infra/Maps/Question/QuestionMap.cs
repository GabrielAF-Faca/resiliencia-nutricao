using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Ufn.Resiliencia.Api.Portal.Infra.Maps.Shared;

using QuestionDomain = Ufn.Resiliencia.Api.Portal.Domain.Entities.Question;

namespace Ufn.Resiliencia.Api.Portal.Infra.Maps.Question;
public class QuestionMap : EntityMap<QuestionDomain>
{
    public override void Configure(EntityTypeBuilder<QuestionDomain> builder)
    {
        builder.Property(b => b.IdQuestionGroup)
            .IsRequired()
            .HasColumnName("id_question_group");
        builder.Property(b => b.QuestionOrder)
            .HasColumnName("question_order");
        builder.Property(b => b.QuestionDescription)
            .HasColumnName("question");
        builder.Property(b => b.FirstAnswer)
            .HasColumnName("first_answer");
        builder.Property(b => b.FirstAnswerNote)
            .HasColumnName("first_answer_note");
        builder.Property(b => b.SecondAnswer)
            .HasColumnName("second_answer");
        builder.Property(b => b.SecondAnswerNote)
            .HasColumnName("second_answer_note");
        builder.Property(b => b.ThirdAnswer)
            .HasColumnName("third_answer");
        builder.Property(b => b.ThirdAnswerNote)
            .HasColumnName("third_answer_note");
        builder.Property(b => b.AdditionalAnswer)
            .HasColumnName("additional_answer");
        builder.Property(b => b.AdditionalAnswerNote)
            .HasColumnName("additional_answer_note");
        builder.Property(b => b.Active)
            .HasColumnName("active");

        builder.ToTable("questions");

        base.Configure(builder);
    }
}
