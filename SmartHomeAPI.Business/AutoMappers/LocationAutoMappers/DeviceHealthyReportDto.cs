using SmartHomeAPI.Business.Abstractions.Dtos;

namespace SmartHomeAPI.Business.AutoMappers.LocationAutoMappers;

public class DeviceHealthyReportDto : IDto
{
    public string HealthyStatus { get; set; } = null!;
    public int Count { get; set; }
}
