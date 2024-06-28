using System.ComponentModel.DataAnnotations;

namespace CellManagerAPI.Application.DTO.DTO;

public class CreateCellsDto : CreateBaseDto
{
    [Required]
    [Range(0, int.MaxValue)]
    public int Number { get; set; }

    [Required]
    [Range(0, int.MaxValue)]
    public int SupervisionId { get; set; }
}
