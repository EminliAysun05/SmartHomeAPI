namespace SmartHomeAPI.Business.Dtos.DeviceCategoryDtos;

public class DeviceCategoryCreateDto 
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
}
public class DeviceCategoryGetDto 
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
}