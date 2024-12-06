namespace Ufn.Resiliencia.Api.Auth.WebApi.Application.Dto.Shared;

internal class Constants
{
    internal const string RegexPassword = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?#])[A-Za-z\d@$!%*?#]{8,256}$";
}
