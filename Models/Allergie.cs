using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASPBookProject.Models;

public class Allergie
{

    public int AllergieId { get; set; }
    [StringLength(30)]
    public required string Libelle_al { get; set; }

    public List<Medicament> Medicaments { get; set; } = new();
    public List<Patient> Patients { get; set; } = new();
}
