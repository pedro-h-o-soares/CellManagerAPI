﻿namespace CellManagerAPI.Domain.Models;

public class Frequenter : Base
{
    public string Name { get; set; }
    public DateOnly? BirthDate { get; set; }
    public int CellId { get; set; }
    public virtual Cell Cell { get; set; }
}
