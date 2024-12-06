namespace Ufn.Resiliencia.Api.Portal.Application.Dto.Answer;
public class AnswerResponseDto
{
    public int Id { get; set; }
    public int IdEstablishment { get; set; }
    public int IdQuestion { get; set; }
    public int IdQuestionnaire { get; set; }

    public string QuestionDescription { get; set; } // Nova propriedade para a descrição da questão
    public string EstablishmentName { get; set; } // Nova propriedade para o nome do estabelecimento
    public string QuestionnaireName { get; set; } // Nova propriedade para o nome do questionário

    public string UniqueCode { get; set; }
    public bool QuestionOneAnswered { get; set; }
    public bool QuestionTwoAnswered { get; set; }
    public bool QuestionThreeAnswered { get; set; }
    public bool AdditionalQuestionAnswered { get; set; }
}
