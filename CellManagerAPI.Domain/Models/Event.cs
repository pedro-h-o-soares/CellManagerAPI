namespace CellManagerAPI.Domain.Models;

public class Event : Base
{
    public string Title { get; set; }
    public DateTime Date { get; set; }
    public int? CellId { get; set; }
    public virtual Cell? Cell { get; set; }
    public virtual ICollection<Member> Members { get; set; }
    public virtual ICollection<Visitor> Visitors { get; set; }
}
