using System;
using System.ComponentModel.DataAnnotations;

namespace ASPBookProject.ViewModels;

public class RegisterViewModel
{
    [StringLength(30)]
    [Required(ErrorMessage = "Le champ Username est requis.")]
    public string UserName { get; set; }

    [StringLength(30)]
    [Required(ErrorMessage = "Le champ Role est requis.")]
    public string Role { get; set; }

    [DataType(DataType.Date)]
    public DateTime Date { get; set; }

    [StringLength(30)]
    [Required(ErrorMessage = "Le champ Password est requis.")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}
