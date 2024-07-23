using System.ComponentModel.DataAnnotations;

namespace CellManagerAPI.Application.DTO.DTO;

public class UpdateUsersDto
{
    [Required]
    public string UserName { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
}
