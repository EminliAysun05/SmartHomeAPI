namespace SmartHomeAPI.Core.Entities;

public class UserDevice 
{
    public int UserId { get; set; }
    public int DeviceId { get; set; }

    public AppUser User { get; set; } = null!;
    public Device Device { get; set; } = null!;
}

