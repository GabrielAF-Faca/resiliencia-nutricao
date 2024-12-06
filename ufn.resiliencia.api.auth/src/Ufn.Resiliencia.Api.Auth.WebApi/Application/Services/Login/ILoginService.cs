using Ufn.Resiliencia.Api.Auth.WebApi.Application.Dto.Login;

namespace Ufn.Resiliencia.Api.Auth.WebApi.Application.Services.Login;
public interface ILoginService
{
    Task<LoginResponseDto?> PerformLoginAsync(LoginDto dto);
}
