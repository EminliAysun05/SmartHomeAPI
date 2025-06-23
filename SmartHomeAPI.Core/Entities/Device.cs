using SmartHomeAPI.Core.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace SmartHomeAPI.Core.Entities;

public class Device : BaseEntity
{
    [Required, MaxLength(100)]
    public string Name { get; set; } = null!;
    public bool IsOnline { get; set; }
    public double PowerUsage { get; set; }

    [MaxLength(20)]
    public string HealthStatus { get; set; } = null!;

    public DeviceCategory Category { get; set; } = null!;
    public int CategoryId { get; set; }

    public Location Location { get; set; } = null!;
    public int LocationId { get; set; }
    public ICollection<SensorReading> SensorReadings { get; set; } = new List<SensorReading>();
    public ICollection<UserDevice> UserDevices { get; set; } = new List<UserDevice>();
}
