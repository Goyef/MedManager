using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASPBookProject.Models;


public class Patient
{
    [Key]
    public int PatientId { get; set; }
    [Required(ErrorMessage ="Le nom est requis")]
    public  string Nom_p { get; set; }

    [Required(ErrorMessage ="Le prénom est requis")]
    public required string Prenom_p { get; set; }
     [Required(ErrorMessage ="Le sexe est requis")]
    public required string Sexe_p { get; set; }

    [StringLength(15, MinimumLength = 15, ErrorMessage = "Num_secu doit avoir 15 de longs")]
    public required string Num_secu { get; set; }

    public List<Antecedent> Antecedents { get; set; } = new();
    public List<Allergie> Allergies { get; set; } = new();
    public List<Ordonnance> Ordonnances { get; set; } = new();
}
