using SmartHomeAPI.Business.Abstractions.Dtos;

namespace SmartHomeAPI.Business.Dtos.LocationDtos;

public class LocationCreateDto 
{
    public string Name { get; set; } = null!;
    public int Floor { get; set; } 
    public string RoomType { get; set; } = null!;
}
public class LocationGetDto 
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int Floor { get; set; }
    public string RoomType { get; set; } = null!;
}

public class LocationWithDevicesDto 
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int Floor { get; set; }
    public string RoomType { get; set; } = null!;
    public List<DeviceDto> Devices { get; set; } = new List<DeviceDto>();
}
public class DeviceDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}
