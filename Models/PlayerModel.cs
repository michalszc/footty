using System.ComponentModel.DataAnnotations;

namespace footty.Models;

public class Player
{
    [Key]
    public int id { get; set; }
    public Team? team { get; set; }
    public String? position { get; set; }
    public String? shirt_number { get; set; }
    public float minutes_played { get; set; }
    public int games_played { get; set; }
    public int assists { get; set; }
    public int goals_scored { get; set; }
}
