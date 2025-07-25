﻿using Microsoft.AspNetCore.Identity;

namespace SmartHomeAPI.Core.Entities;

public class AppUser : IdentityUser
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
}
