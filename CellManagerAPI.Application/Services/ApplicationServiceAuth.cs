using AutoMapper;
using CellManagerAPI.Application.DTO.DTO.Auth;
using CellManagerAPI.Application.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CellManagerAPI.Application.Services;

public class ApplicationServiceAuth : IApplicationServiceAuth
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;

    public ApplicationServiceAuth(
        UserManager<IdentityUser> userManager,
        RoleManager<IdentityRole> roleManager,
        IConfiguration configuration,
        IMapper mapper)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _configuration = configuration;
        _mapper = mapper;
    }

    public async Task<TokenDto> Login(UserInfoDto userInfo)
    {
        var user = await _userManager.FindByEmailAsync(userInfo.Email);
        if (!CanLogin(user, userInfo.Password)) throw new UnauthorizedAccessException("Email or Password are incorrects");

        var userRoles = await _userManager.GetRolesAsync(user);

        var authClaims = new List<Claim>
        {
            new (ClaimTypes.Name, user.UserName),
            new (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        foreach (var userRole in userRoles)
        {
            authClaims.Add(new Claim(ClaimTypes.Role, userRole));
        }

        var expires = DateTime.Now.AddHours(int.Parse(_configuration["JWT:ExpireTimeHours"]));
        var token = GetToken(authClaims, expires);

        return new TokenDto()
        {
            Email = userInfo.Email,
            Id = user.Id,
            Roles = userRoles,
            Expiration = expires,
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            Username = user.UserName,
        };
    }

    public async Task Register(CreateUserDto dto)
    {
        var user = _mapper.Map<IdentityUser>(dto);
        user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, dto.Password);

        var result = await _userManager.CreateAsync(user);

        if (!result.Succeeded)
        {
            throw new UnauthorizedAccessException(result.Errors.First().Description);
        }
    }

    private bool CanLogin(IdentityUser? user, string password)
    {
        return user is not null && _userManager.CheckPasswordAsync(user, password).GetAwaiter().GetResult();
    }

    private JwtSecurityToken GetToken(List<Claim> authClaims, DateTime expires)
    {
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

        var token = new JwtSecurityToken(
            issuer: _configuration["JWT:ValidIssuer"],
            audience: _configuration["JWT:ValidAudience"],
            expires: expires,
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

        return token;
    }
}
