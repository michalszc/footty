using System.ComponentModel.DataAnnotations;

namespace footty.Models;

public class Table
{
    public int id { get; set; }
    public string? Team { get; set; }
    public int Goals { get; set; }
    public int Conceeded { get; set; }
}