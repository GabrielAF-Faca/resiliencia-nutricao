namespace Ufn.Resiliencia.Api.Portal.Infra.Repositories.MySQL.Question;
public static class QuestionStatements
{
    public static string QuestionHasAnswers = @"
        SELECT 1
        FROM answers
        WHERE id_question = @Id
    ";
}
