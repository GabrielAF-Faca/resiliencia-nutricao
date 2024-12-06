namespace Ufn.Resiliencia.Api.Portal.Infra.Repositories.MySQL.RespondentGroup;
public static class RespondentGroupStatements
{
    public static string RespondentGroupHasQuestionnaires = @"
        SELECT 1
        FROM questionnaires
        WHERE id_respondent_group = @Id;
    ";
}
