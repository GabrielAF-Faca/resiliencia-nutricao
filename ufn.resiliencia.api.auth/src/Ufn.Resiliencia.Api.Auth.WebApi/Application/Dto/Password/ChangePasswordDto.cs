using System.Text.Json.Serialization;

using Ufn.Resiliencia.Api.Auth.WebApi.Application.Dto.Shared;

namespace Ufn.Resiliencia.Api.Auth.WebApi.Application.Dto.Password;

public class ChangePasswordDto : BaseDto
{
    [JsonIgnore]
    public string? UserId { get; set; }
    public string ActualPassword { get; set; }
    public string NewPassword { get; set; }
    public string ConfirmNewPassword { get; set; }
}
