using SmartHomeAPI.Business.Abstractions.Dtos;

namespace SmartHomeAPI.Business.Dtos.AppUserDtos;

public class UserGetDto : IDto
{
    public string Id { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
}
