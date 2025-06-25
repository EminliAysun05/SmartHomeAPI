using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SmartHomeAPI.Core.Entities;
using SmartHomeAPI.Core.Entities.Enum;
using SmartHomeAPI.DataAccess.Data;

namespace SmartHomeAPI.DataAccess.DataInitializers;

public class DbContextInitializer
{
    private readonly AppDbContext _context;
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly AdminSettings _adminSettings;

    public DbContextInitializer(
        AppDbContext context,
        UserManager<AppUser> userManager,
        RoleManager<IdentityRole> roleManager,
        IConfiguration configuration)
    {
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
        _adminSettings = configuration.GetSection("AdminSettings").Get<AdminSettings>() ?? new();
    }

    public async Task InitDatabaseAsync()
    {
        await _context.Database.MigrateAsync();
        await _createRolesAsync();
        await _createAdminAsync();
    }

    private async Task _createAdminAsync()
    {
        var isExist = await _userManager.Users.AnyAsync(x => x.UserName == _adminSettings.UserName);

        if (!isExist)
        {
            var adminUser = new AppUser
            {
                UserName = _adminSettings.UserName,
                Email = _adminSettings.Email,
                FirstName = _adminSettings.FirstName,
                LastName = _adminSettings.LastName
            };

            await _userManager.CreateAsync(adminUser, _adminSettings.Password);
            await _userManager.AddToRoleAsync(adminUser, IdentityRoles.Admin.ToString());
        }
    }

    private async Task _createRolesAsync()
    {
        foreach (string role in Enum.GetNames(typeof(IdentityRoles)))
        {
            var isExist = await _roleManager.Roles.AnyAsync(x => x.Name == role);
            if (isExist) continue;

            IdentityRole identityRole = new() { Name = role };
            await _roleManager.CreateAsync(identityRole);
        }
    }
}



