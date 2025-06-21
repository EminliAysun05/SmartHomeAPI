using SmartHomeAPI.Business.Abstractions.Dtos;

namespace SmartHomeAPI.Business.Dtos.AppUserDtos;

public class LoginDto : IDto
{
    public string UserName { get; set; }
    public string Password { get; set; }
   
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}
public class RegisterDto : IDto
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string? Email { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}
//public class UserGetDto : IDto
//{
//    public string Id { get; set; } = null!;
//    public string Name { get; set; } = null!;
//    public string Surname { get; set; } = null!;
//    public string Username { get; set; } = null!;
//    public string Email { get; set; } = null!;
//    public string Role { get; set; } = null!;
//}
