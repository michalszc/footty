using System.ComponentModel.DataAnnotations;

namespace footty.Models;

public class Stadium
{
    [Key]
    public int id { get; set; }
    [Display(Name = "Team")]
    public Team? team { get; set; }
    [Display(Name = "City")]
    public String? city { get; set; }
    [Display(Name = "Name")]
    public String? name { get; set; }
    [Display(Name = "Capacity")]
    public int capacity { get; set; }
    [Display(Name = "Latitude")]
    public float latitude { get; set; }
    [Display(Name = "Longitude")]
    public float longitude { get; set; }
}
