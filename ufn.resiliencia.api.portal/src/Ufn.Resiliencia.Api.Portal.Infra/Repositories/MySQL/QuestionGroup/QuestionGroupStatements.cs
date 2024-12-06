namespace Ufn.Resiliencia.Api.Portal.Infra.Repositories.MySQL.QuestionGroup;
public static class QuestionGroupStatements
{
    public static string QuestionGroupHasQuestions = @"
        SELECT 1
        FROM questions
        WHERE id_question_group = @Id
    ";
}
