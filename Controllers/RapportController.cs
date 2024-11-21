using System.ComponentModel;
using ASPBookProject.Data;
using ASPBookProject.Models;
using ASPBookProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPBookProject.Controllers
{
    public class RapportController : Controller
    {

        private readonly UserManager<Medecin> _userManager;
        private readonly ApplicationDbContext _context;
        
        public RapportController(UserManager<Medecin> userManager, ApplicationDbContext context)
        {
            _context = context;
            _userManager = userManager;
        }
        [Authorize]
        public async Task<ActionResult> Index()
        {
            return View();

        }
        [Authorize]
        public async Task<ActionResult> MedRanking()
        {
            List<Medicament> medicaments = new List<Medicament>();
            medicaments = await _context.Medicaments
                                .ToListAsync();
           medicaments = medicaments.OrderByDescending(o => o.compteur).ToList();
            return View(medicaments);

        }
        [Authorize]
        public IActionResult PeriodPrescription()
        {

        PeriodPrescriptionViewModel viewModel = new PeriodPrescriptionViewModel {
            DateDebut = DateTime.Now,
            DateFin = DateTime.Now.AddDays(1)
        };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PeriodPrescription(PeriodPrescriptionViewModel viewModel)
{
    if (viewModel.DateDebut > viewModel.DateFin)
    {
        ModelState.AddModelError("", "Vérifiez les dates.");
        return View(viewModel);
    }
    string? medecinId = _userManager.GetUserId(User);
    List<Ordonnance> ordonnancesPeriod = await _context.Ordonnances
        .Where(o => o.Date_debut >= viewModel.DateDebut && o.Date_fin <= viewModel.DateFin)
        .Include(o => o.Patient)
        .Include(o => o.Medecin)
        .Include(o => o.Medicaments).Where(m => m.MedecinId == medecinId)
        .ToListAsync();

    return View("PeriodPrescriptionShow", ordonnancesPeriod);
}
    }
}
