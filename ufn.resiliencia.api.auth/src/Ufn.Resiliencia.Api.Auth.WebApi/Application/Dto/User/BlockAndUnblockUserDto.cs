using System.Text.Json.Serialization;

using Ufn.Resiliencia.Api.Auth.WebApi.Application.Dto.Shared;

namespace Ufn.Resiliencia.Api.Auth.WebApi.Application.Dto.User;

public class BlockAndUnblockUserDto : BaseDto
{
    public string Username { get; set; }
    [JsonIgnore]
    public bool IsBlocked { get; set; }
}
