using CellManagerAPI.Application.DTO.DTO.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace CellManagerAPI.Application.Interfaces;

public interface IApplicationServiceAuth
{
    Task<TokenDto> Login(UserInfoDto userInfo);
    Task Register(CreateUserDto dto);
}
