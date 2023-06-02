using System.ComponentModel.DataAnnotations;

namespace footty.Models;

public class Match
{
    [Key]
    public int id { get; set; }
    [Display(Name = "Date")]
    public String? date { get; set; }
    [Display(Name = "Team")]
    public Team? team { get; set; }
    [Display(Name = "Opponent")]
    public Team? opponent { get; set; }
    [Display(Name = "Place")]
    public String? place { get; set; }
    [Display(Name = "Team goals")]
    public int team_goals { get; set; }
    [Display(Name = "Opponent goals")]
    public int opponent_goals { get; set; }
}
