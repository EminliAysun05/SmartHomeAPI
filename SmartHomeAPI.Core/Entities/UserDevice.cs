using SmartHomeAPI.Core.Entities.Common;

namespace SmartHomeAPI.Core.Entities;

public class UserDevice : BaseEntity
{
    public int UserId { get; set; }
    public int DeviceId { get; set; }

    public AppUser User { get; set; } = null!;
    public Device Device { get; set; } = null!;
}

