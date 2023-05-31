using System.ComponentModel.DataAnnotations;

namespace footty.Models;

public class Match
{
    [Key]
    public int id { get; set; }
    public String? date { get; set; }
    public int team { get; set; }
    public int opponent { get; set; }
    public String? place { get; set; }
    public int team_goals { get; set; }
    public int opponent_goals { get; set; }
}
