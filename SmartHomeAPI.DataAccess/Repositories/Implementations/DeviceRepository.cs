﻿using SmartHomeAPI.Core.Entities;
using SmartHomeAPI.Core.Repositories.Abstractions;
using SmartHomeAPI.DataAccess.Data;
using SmartHomeAPI.DataAccess.Repositories.Implementations.Generic;

namespace SmartHomeAPI.DataAccess.Repositories.Implementations;

public class DeviceRepository : Repository<Device>, IDeviceRepository
{
    public DeviceRepository(AppDbContext context) : base(context)
    {
    }
}

