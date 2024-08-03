using CellManagerAPI.Application.DTO.DTO;
using CellManagerAPI.Application.DTO.DTO.Auth;

namespace CellManagerAPI.Application.Interfaces;

public interface IApplicationServiceAuth
{
    Task<TokenDto> Login(UserInfoDto userInfo);
    Task Register(CreateUsersDto dto);
}
