﻿namespace Ufn.Resiliencia.Api.Portal.Application.Dto.Questionnaire;
public class QuestionResponseDto
{
    public int IdQuestionGroup { get; set; }

    public int Id { get; set; }
    public int QuestionOrder { get; set; }
    public string QuestionDescription { get; set; }
    public string FirstAnswer { get; set; }
    public int FirstAnswerNote { get; set; }
    public string SecondAnswer { get; set; }
    public int SecondAnswerNote { get; set; }
    public string? ThirdAnswer { get; set; }
    public int? ThirdAnswerNote { get; set; }

    public string? AdditionalAnswer { get; set; }
    public int? AdditionalAnswerNote { get; set; }
    public bool Active { get; set; }
}
