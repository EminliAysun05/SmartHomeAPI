using SmartHomeAPI.Core.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace SmartHomeAPI.Core.Entities;

public class SensorReading : BaseEntity
{
    public double Value { get; set; }

    [MaxLength(20)]
    public string Unit { get; set; } = null!;// e.g., "Celsius", "Fahrenheit", "Lux", "Percentage"

    [MaxLength(50)]
    public string ReadingType { get; set; } = null!; // e.g., "Temperature", "Humidity", "Light", "Motion"

    public DateTime Timestamp { get; set; }
    public Device Device { get; set; } = null!;
    public int DeviceId { get; set; }
}
