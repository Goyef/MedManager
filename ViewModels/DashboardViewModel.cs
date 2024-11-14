using System;
using ASPBookProject.Models;

namespace ASPBookProject.ViewModels;

public class DashboardViewModel
{
    public List<Ordonnance> Ordonnances { get; set; }
    public List<Patient> RecentPatients { get; set; } // Nouvelle propriété pour les patients récents
}