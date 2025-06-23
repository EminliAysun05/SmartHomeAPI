using SmartHomeAPI.Business.Abstractions.Dtos;

namespace SmartHomeAPI.Business.Dtos.AnalyticDtos;

public class LocationUsageDto : IDto
{
    public string LocationName { get; set; } = null!;
    public int DeviceCount { get; set; }
}
