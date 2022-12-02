using System;

namespace Source.Models;

public abstract class Human
{
    public string? Surname { get; set; }
    public string? Name { get; set; }
    public DateTime BrithDay { get; set; }
}
