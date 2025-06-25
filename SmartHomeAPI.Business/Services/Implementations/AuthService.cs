using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SmartHomeAPI.Business.Dtos.AppUserDtos;
using SmartHomeAPI.Business.Services.Abstractions;
using SmartHomeAPI.Core.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SmartHomeAPI.Business.Services.Implementations;

public class AuthService : IAuthService
{

    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly IConfiguration _config;
    private readonly IMapper _mapper;


    public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IConfiguration config, IMapper mapper)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _config = config;
        _mapper = mapper;
    }



    public async Task<(bool succes, string message)> RegisterAsync(RegisterDto model)
    {
        if (string.IsNullOrEmpty(model.FirstName) || string.IsNullOrEmpty(model.LastName))
        {

            return (false, "FirstName and LastName are required");
        }

        var user = new AppUser
        {
            UserName = model.UserName,
            Email = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName
           
        };

        var result = await _userManager.CreateAsync(user, model.Password);

        if (result.Succeeded)
            return (true, "User registered successfully");

        return (false, string.Join(", ", result.Errors.Select(e => e.Description)));
    }

    public async Task<(bool succes, string message, string? Token)> LoginAsync(LoginDto model)
    {
        var user = await _userManager.FindByNameAsync(model.UserName);

        if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
            return (false, "Invalid credentials", null);

        var token = GenerateToken(user);
        return (true, "Login successful", token);
    }


    private string GenerateToken(AppUser user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]!));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
                new Claim(ClaimTypes.Name, user.UserName!),
                new Claim(ClaimTypes.Email, user.Email!)
            };

        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: credentials
            );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public async Task<List<UserGetDto>> GetAllUserAsync()
    {
        var users =  _userManager.Users.ToList();
        var dtos = _mapper.Map<List<UserGetDto>>(users);
        return dtos;
    }

}
