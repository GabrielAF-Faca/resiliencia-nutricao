namespace Ufn.Resiliencia.Api.Portal.Infra.Repositories.MySQL.Establishment;
public static class EstablishmentStatements
{
    public static string EstablishmentHasQuestionnaires = @"
        SELECT 1
        FROM establishment_questionnaires
        WHERE id_establishment = @Id
    ";
}
