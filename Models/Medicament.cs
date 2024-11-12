using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASPBookProject.Models;

public class Medicament
{
    public int MedicamentId { get; set; }
    [StringLength(50)]
    public required string Libelle_med { get; set; }
    public required string Contr_indication { get; set; }

    public int compteur {get;set;}

    public List<Allergie> Allergies { get; set; } = new();
    public List<Antecedent> Antecedents { get; set; } = new();
    public List<Ordonnance> Ordonnances { get; set; } = new();
}
