using System.ComponentModel.DataAnnotations;

namespace footty.Models;

public class User
{
    [Key]
    public int id { get; set; }
    public string? username { get; set; }
    public string? password { get; set; }
    [Display(Name = "can edit")]
    public Boolean can_edit { get; set; }
    public string? token { get; set; }
}
