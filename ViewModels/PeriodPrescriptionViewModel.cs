using System;
using System.ComponentModel.DataAnnotations;

namespace ASPBookProject.ViewModels;

public class PeriodPrescriptionViewModel
{
    [DataType(DataType.Date)]
     [Required(ErrorMessage = "Le date de début est obligatoire")]
    public DateTime? DateDebut { get; set; }

    [DataType(DataType.Date)]
     [Required(ErrorMessage = "Le date de fin est obligatoire")]
    public DateTime? DateFin { get; set; }
}
