using System;
using System.ComponentModel.DataAnnotations;
using ASPBookProject.Models;

namespace ASPBookProject.ViewModels;

public class OrdonnanceEditViewModel
{
    [Required]
    public Ordonnance? Ordonnance { get; set; }
    public List<Medecin> Medecins { get; set; }
    public List<Patient> Patients { get; set; }
    public List<Medicament>? Medicaments { get; set; }
    public List<int> SelectedMedicamentId { get; set; } = new List<int>();
}
