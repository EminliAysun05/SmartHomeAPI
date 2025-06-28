using SmartHomeAPI.Business.Abstractions.Dtos;

namespace SmartHomeAPI.Business.Dtos.SensorReadingDtos;

public class SensorReadingCreateDto 
{
    public double Value { get; set; }
    public string Unit { get; set; } = null!;
    public string ReadingType { get; set; } = null!;
    public DateTime Timestamp { get; set; }
    public int DeviceId { get; set; }
}

public class SensorReadingGetDto
{
    public int Id { get; set; }
    public double Value { get; set; }
    public string Unit { get; set; } = null!;
    public string ReadingType { get; set; } = null!;
    public DateTime Timestamp { get; set; }
    public int DeviceId { get; set; }
}
