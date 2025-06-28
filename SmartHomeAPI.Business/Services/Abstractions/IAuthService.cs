using SmartHomeAPI.Business.Dtos.AppUserDtos;

namespace SmartHomeAPI.Business.Services.Abstractions;

public interface IAuthService
{
  
    Task<(bool succes, string message)> RegisterAsync(RegisterDto model);
    Task<(bool succes, string message, string? Token)> LoginAsync(LoginDto model);
    Task<List<UserGetDto>> GetAllUserAsync();
    Task<(bool success, string message)> RegisterAdminAsync(RegisterDto model);
}
