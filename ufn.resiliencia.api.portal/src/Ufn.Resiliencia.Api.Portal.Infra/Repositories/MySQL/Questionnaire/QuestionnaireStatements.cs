namespace Ufn.Resiliencia.Api.Portal.Infra.Repositories.MySQL.Questionnaire;
public static class QuestionnaireStatements
{
    public static string QuestionnaireHasQuestionsGroup = @"
        SELECT 1
        FROM question_groups
        WHERE id_questionnaire = @Id
    ";

    public static string GetAllBasic = @"
        SELECT
            id AS Id,
            id_respondent_group AS IdRespondentGroup,
            description AS Description,
            active AS Active
        FROM questionnaires
    ";

    public static string GetAllBasicByEstablishment = @"
        select
            q.id as Id,
            q.id_respondent_group as IdRespondentGroup,
            q.description as Description,
            q.active as Active
        from establishment_questionnaires eq
            inner join questionnaires q on eq.id_questionnaire = q.id
        where eq.id_establishment = @EstablishmentId
    ";

}
