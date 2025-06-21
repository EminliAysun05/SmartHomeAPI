using SmartHomeAPI.Core.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace SmartHomeAPI.Core.Entities;

public class Location : BaseEntity
{
    [Required, MaxLength(100)]
    public string Name { get; set; } = null!;
    public int Floor { get; set; }

    [MaxLength(50)]
    public string RoomType { get; set; } = null!;
    public ICollection<Device> Devices { get; set; } = new List<Device>();
}
