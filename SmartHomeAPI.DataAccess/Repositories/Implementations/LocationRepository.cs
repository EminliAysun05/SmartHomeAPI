﻿using SmartHomeAPI.Core.Entities;
using SmartHomeAPI.Core.Repositories.Abstractions;
using SmartHomeAPI.DataAccess.Data;
using SmartHomeAPI.DataAccess.Repositories.Implementations.Generic;

namespace SmartHomeAPI.DataAccess.Repositories.Implementations;

public class LocationRepository : Repository<Location>, ILocationRepository
{
    public LocationRepository(AppDbContext context) : base(context)
    {
    }
}

