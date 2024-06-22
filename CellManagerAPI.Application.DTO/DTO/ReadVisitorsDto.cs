namespace CellManagerAPI.Application.DTO.DTO;

public class ReadVisitorsDto : ReadBaseDto
{
    public string Name { get; set; }
    public DateOnly? BirthDate { get; set; }
    public int CellNumber { get; set; }
}