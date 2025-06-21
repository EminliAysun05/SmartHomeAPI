using Microsoft.AspNetCore.Mvc.ModelBinding;
using SmartHomeAPI.Business.Dtos.AppUserDtos;

namespace SmartHomeAPI.Business.Services.Abstractions;

public interface IAuthService
{
    //Task<bool> RegisterAsync(RegisterDto dto, ModelStateDictionary ModelState);
    //Task<bool> LoginAsync(LoginDto dto, ModelStateDictionary ModelState);
    //Task<bool> LogoutAsync();
    //Task<List<UserGetDto>> GetAllUserAsync();
    //Task<UserGetDto> GetUserAsync(string id);

    Task<(bool succes, string message)> RegisterAsync(RegisterDto model);
        Task<(bool succes, string message, string? Token)> LoginAsync(LoginDto model);
}
