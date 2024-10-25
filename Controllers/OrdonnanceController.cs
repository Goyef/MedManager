using ASPBookProject.Data;
using ASPBookProject.Models;
using ASPBookProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ASPBookProject.Controllers
{
    public class OrdonnanceController : Controller
    {
        private readonly ApplicationDbContext _context;
        public List<SelectListItem> Options { get; set; }
        // Controleur, injection de dependance
        public OrdonnanceController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: OrdonnanceController
        [Authorize]
        public async Task<IActionResult> Index()
        {
            List<Ordonnance> ordonnances = new List<Ordonnance>();
            ordonnances = await _context.Ordonnances.ToListAsync();
            ordonnances.OrderByDescending(o => o.Patient.Nom_p);

            return View(ordonnances);
        }
        // public IActionResult Add()
        // {
        //     return View();
        // }

        // [HttpPost]
        // public IActionResult Add(Antecedent antecedent)
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return View();
        //     }

        //     _context.Antecedents.Add(antecedent);
        //     _context.SaveChanges();
        //     return RedirectToAction("Index");
        // }

        public async Task<IActionResult> Add()
        {
            var viewModel = new OrdonnanceEditViewModel
            {

                Medecins = await _context.Users.ToListAsync(),
                Patients = await _context.Patients.ToListAsync(),
                Medicaments = await _context.Medicaments.ToListAsync(),
                SelectedMedicamentId = new List<int>(),

            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(OrdonnanceEditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("Ordonnance : ", viewModel.Ordonnance.Medecin);
                viewModel.Medecins = await _context.Users.ToListAsync();
                viewModel.Patients = await _context.Patients.ToListAsync();
                viewModel.Medicaments = await _context.Medicaments.ToListAsync();
                return View(viewModel);
            }
            int result = DateTime.Compare(viewModel.Ordonnance.Date_debut, viewModel.Ordonnance.Date_fin);
            if (result > 0)
            {
                ModelState.AddModelError("", "Vérifier les dates");
                viewModel.Medecins = await _context.Users.ToListAsync();
                viewModel.Patients = await _context.Patients.ToListAsync();
                viewModel.Medicaments = await _context.Medicaments.ToListAsync();
                return View(viewModel);
            }
            Ordonnance ordonnance = new Ordonnance
            {
                Posologie = viewModel.Ordonnance.Posologie,
                Date_debut = viewModel.Ordonnance.Date_debut,
                Date_fin = viewModel.Ordonnance.Date_fin,
                Instructions_specifique = viewModel.Ordonnance.Instructions_specifique,
                Medecin = viewModel.Ordonnance.Medecin,
                Patient = viewModel.Ordonnance.Patient,
                Medicaments = new List<Medicament>()
            };
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("Ordonnance : ", ordonnance.Medecin.UserName);
            if (viewModel.SelectedMedicamentId != null)
            {
                var SelectedMedicamentId = await _context.Medicaments
                    .Where(m => viewModel.SelectedMedicamentId.Contains(m.MedicamentId))
                    .ToListAsync();
                foreach (var medicament in SelectedMedicamentId)
                {
                    ordonnance.Medicaments.Add(medicament);
                }
            }

            _context.Ordonnances.Add(ordonnance);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
