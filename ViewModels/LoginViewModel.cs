using System.ComponentModel.DataAnnotations;

namespace ASPBookProject.ViewModels;

public class LoginViewModel
{
    [StringLength(30)]
    [Required(ErrorMessage = "Le champ UserName est requis.")]
    public string UserName { get; set; }

    [StringLength(30)]
    [Required(ErrorMessage = "Le champ mot de passe est requis.")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Display(Name = "Remember me?")]
    public bool RememberMe { get; set; }

}