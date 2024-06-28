using System.ComponentModel.DataAnnotations;

namespace CellManagerAPI.Application.DTO.DTO;

public class CreateVisitorsDto : CreateBaseDto
{
    [Required]
    [MaxLength(255)]
    public string Name { get; set; }
    public DateOnly? BirthDate { get; set; }
    public int CellId { get; set; }
}
