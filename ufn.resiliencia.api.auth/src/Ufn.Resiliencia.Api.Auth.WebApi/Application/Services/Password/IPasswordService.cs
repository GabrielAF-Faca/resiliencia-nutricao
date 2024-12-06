using Ufn.Resiliencia.Api.Auth.WebApi.Application.Dto.Password;

namespace Ufn.Resiliencia.Api.Auth.WebApi.Application.Services.Password;

public interface IPasswordService
{
    Task ChangePasswordAsync(ChangePasswordDto dto);
}
