using SmartHomeAPI.Core.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace SmartHomeAPI.Core.Entities;

public class DeviceCategory : BaseEntity
{
    [Required, MaxLength(50)]
    public string Name { get; set; }

    [MaxLength(250)]
    public string Description { get; set; }

    public ICollection<Device> Devices { get; set; } = new List<Device>();  
}
