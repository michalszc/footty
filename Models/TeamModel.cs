using System.ComponentModel.DataAnnotations;

namespace footty.Models;

public class Team
{
    [Key]
    public int id { get; set; }
    public string? name { get; set; }
}
