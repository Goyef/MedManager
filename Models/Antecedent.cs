using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASPBookProject.Models;

public class Antecedent
{

    public int AntecedentId { get; set; }
    [StringLength(30)]
    public required string Libelle_a { get; set; }

    public List<Medicament> Medicaments { get; set; } = new();
    public List<Patient> Patients { get; set; } = new();
}
