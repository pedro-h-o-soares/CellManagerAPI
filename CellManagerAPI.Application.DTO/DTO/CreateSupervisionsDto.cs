using System.ComponentModel.DataAnnotations;

namespace CellManagerAPI.Application.DTO.DTO;

public class CreateSupervisionsDto : CreateBaseDto
{
    [Required]
    [MaxLength(255)]
    public string Color { get; set; }
}
