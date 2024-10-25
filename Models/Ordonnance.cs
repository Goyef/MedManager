using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPBookProject.Models;

public class Ordonnance
{
    public int OrdonnanceId { get; set; }

    [StringLength(100)]
    [Required(ErrorMessage = "La posologie est requise")]
    public string Posologie { get; set; }

    [DataType(DataType.Date)]
    public required DateTime Date_debut { get; set; }

    [DataType(DataType.Date)]
    public required DateTime Date_fin { get; set; }
    public required string Instructions_specifique { get; set; }

    public string MedecinId { get; set; }

    [Required(ErrorMessage = "Le médecin est requis")]
    public Medecin Medecin { get; set; }
    public int PatientId { get; set; }

    [Required(ErrorMessage = "Le patient est requis")]
    public Patient Patient { get; set; }

    public List<Medicament> Medicaments { get; set; } = new();
}
