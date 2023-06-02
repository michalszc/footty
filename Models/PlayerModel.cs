using System.ComponentModel.DataAnnotations;

namespace footty.Models;

public class Player
{
    [Key]
    public int id { get; set; }
    [Display(Name = "Team")]
    public Team? team { get; set; }
    [Display(Name = "Position")]
    public String? position { get; set; }
    [Display(Name = "Shirt number")]
    public String? shirt_number { get; set; }
    [Display(Name = "Minutes played")]
    public float minutes_played { get; set; }
    [Display(Name = "Games played")]
    public int games_played { get; set; }
    [Display(Name = "Assists")]
    public int assists { get; set; }
    [Display(Name = "Goals scored")]
    public int goals_scored { get; set; }
}
