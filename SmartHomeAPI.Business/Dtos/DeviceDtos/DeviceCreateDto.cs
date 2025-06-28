using SmartHomeAPI.Business.Abstractions.Dtos;

namespace SmartHomeAPI.Business.Dtos.DeviceDtos;

public class DeviceCreateDto 
{
    public string Name { get; set; } = null!;
    public bool IsOnline { get; set; }
    public double PowerUsage { get; set; }
    public string HealthStatus { get; set; } = null!;
    public int CategoryId { get; set; }
    public int LocationId { get; set; }
}

public class DeviceGetDto 
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public bool IsOnline { get; set; }
    public double PowerUsage { get; set; }
    public string HealthStatus { get; set; } = null!;
    public int CategoryId { get; set; }
    public int LocationId { get; set; }
}
public class DeviceUpdateDto
{
    public string Name { get; set; } = null!;
    public bool IsOnline { get; set; }
    public double PowerUsage { get; set; }
    public string HealthStatus { get; set; } = null!;
    public int CategoryId { get; set; }
    public int LocationId { get; set; }
}

