using System.ComponentModel.DataAnnotations;

namespace CellManagerAPI.Application.DTO.DTO;

public class CreateMembersDto : CreateBaseDto
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    [Required]
    public DateOnly BirthDate { get; set; }
    public int? CellId { get; set; }
}
