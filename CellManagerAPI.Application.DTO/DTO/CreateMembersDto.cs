namespace CellManagerAPI.Application.DTO.DTO;

public class CreateMembersDto : CreateBaseDto
{
    public string Name { get; set; }
    public DateOnly BirthDate { get; set; }
    public int? CellId { get; set; }
}
