using System.ComponentModel.DataAnnotations;

namespace CellManagerAPI.Application.DTO.DTO;

public class CreateEventsDto : CreateBaseDto
{
    [Required]
    public string Title { get; set; }
    [Required]
    public DateTime Date { get; set; }
    [Range(0, int.MaxValue)]
    public int? CellId { get; set; }
}