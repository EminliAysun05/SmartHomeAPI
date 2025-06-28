using SmartHomeAPI.Core.Entities;
using SmartHomeAPI.Core.Repositories.Abstractions;
using SmartHomeAPI.DataAccess.Data;
using SmartHomeAPI.DataAccess.Repositories.Implementations.Generic;

namespace SmartHomeAPI.DataAccess.Repositories.Implementations;

public class SensorReadingRepository : Repository<SensorReading>, ISensorReadingRepository
{
    public SensorReadingRepository(AppDbContext context) : base(context)
    {
        
    }
}
