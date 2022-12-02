using System;
using System.Collections.Generic;


namespace Source.Models;

public class User: Human
{
    public Guid Id { get; set; }//
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }//
    public bool RememberMe { get; set; }
    public List<Movie>? Movies { get; set; } = new();
}
