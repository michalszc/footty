using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace footty.Models;

public class User
{
    [Key]
    public int id { get; set; }
    public string? username { get; set; }
    public string? password { get; set; }
    [Display(Name = "Can edit")]
    public Boolean can_edit { get; set; }
    public string? token { get; set; }
    [Display(Name = "Favourite team")]
    public Team? favTeam { get; set; }
}
