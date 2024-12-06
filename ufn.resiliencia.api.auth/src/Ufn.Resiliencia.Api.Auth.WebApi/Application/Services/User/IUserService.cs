using Ufn.Resiliencia.Api.Auth.WebApi.Application.Dto.User;

namespace Ufn.Resiliencia.Api.Auth.WebApi.Application.Services.User;

public interface IUserService
{
    Task<string?> RegisterUser(RegisterUserDto dto);
    Task UpdateUser(UpdateUserDto dto);
    Task BlockAndUnblockUserAsync(BlockAndUnblockUserDto dto);
    Task<IEnumerable<UserResponseDto>?> GetAll(string? id);
    Task<UserResponseDto> Get(string id);
}
