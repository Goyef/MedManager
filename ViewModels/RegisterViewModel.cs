using System;
using System.ComponentModel.DataAnnotations;

namespace ASPBookProject.ViewModels;

public class RegisterViewModel
{
    [Required(ErrorMessage = "The Username field is required.")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "The Login field is required.")]
    public string Login_m {get; set;}

    [Required(ErrorMessage = "The Role field is required.")]
    public string Role {get; set;}

     [Required(ErrorMessage = "The Role field is required.")]
     [DataType(DataType.Date)]
    public DateTime Date {get; set;}

    [Required(ErrorMessage = "The Password field is required.")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}
