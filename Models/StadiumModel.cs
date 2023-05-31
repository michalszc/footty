using System.ComponentModel.DataAnnotations;

namespace footty.Models;

public class Stadium
{
    [Key]
    public int id { get; set; }
    public int team { get; set; }
    public String? city { get; set; }
    public String? name { get; set; }
    public int capacity { get; set; }
    public float latitude { get; set; }
    public float longitude { get; set; }
}
