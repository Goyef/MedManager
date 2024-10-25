using ASPBookProject.Data;
using ASPBookProject.Models;
using ASPBookProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPBookProject.Controllers
{
    public class MedicamentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MedicamentController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: MedicamentController
        [Authorize]
        public IActionResult Index(string searchString)
        {
            var medicaments = from m in _context.Medicaments select m;
            if (!string.IsNullOrEmpty(searchString))
            {
                medicaments = medicaments.Where(m => m.Libelle_med.Contains(searchString));
                return View(medicaments);
            }
            return View(medicaments);
        }

        public async Task<IActionResult> ShowDetails(int id)
        {
            var medicament = await _context.Medicaments
                  .Include(m => m.Antecedents)
                  .Include(m => m.Allergies)
                  .FirstOrDefaultAsync(m => m.MedicamentId == id);

            if (medicament == null)
                return NotFound();

            var viewModel = new MedicamentEditViewModel
            {
                Medicament = medicament,
                Antecedents = medicament.Antecedents.ToList(),
                Allergies = medicament.Allergies.ToList()

            };

            return View(viewModel);
        }

        public async Task<IActionResult> Add()
        {
            var viewModel = new MedicamentEditViewModel
            {
                Antecedents = await _context.Antecedents.ToListAsync(),
                Allergies = await _context.Allergies.ToListAsync(),
                SelectedAntecedentIds = new List<int>(),
                SelectedAllergieIds = new List<int>()
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(MedicamentEditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Antecedents = await _context.Antecedents.ToListAsync();
                viewModel.Allergies = await _context.Allergies.ToListAsync();
                return View(viewModel);
            }
            Medicament medicament = new Medicament
            {
                Libelle_med = viewModel.Medicament.Libelle_med,
                Contr_indication = viewModel.Medicament.Contr_indication,
                Allergies = new List<Allergie>(),
                Antecedents = new List<Antecedent>()
            };

            if (viewModel.SelectedAllergieIds != null)
            {
                var selectedAllergies = await _context.Allergies
                    .Where(a => viewModel.SelectedAllergieIds.Contains(a.AllergieId))
                    .ToListAsync();
                foreach (var allergie in selectedAllergies)
                {
                    medicament.Allergies.Add(allergie);
                }
            }
            if (viewModel.SelectedAntecedentIds != null)
            {
                var selectedAntecedents = await _context.Antecedents
                    .Where(a => viewModel.SelectedAntecedentIds.Contains(a.AntecedentId))
                    .ToListAsync();
                foreach (var antecedent in selectedAntecedents)
                {
                    medicament.Antecedents.Add(antecedent);
                }
            }
            _context.Medicaments.Add(medicament);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int id)
        {
            var medicament = await _context.Medicaments
                .Include(m => m.Antecedents)
                .Include(m => m.Allergies)
                .FirstOrDefaultAsync(m => m.MedicamentId == id);

            if (medicament == null)
                return NotFound();

            var viewModel = new MedicamentEditViewModel
            {
                Medicament = medicament,
                Antecedents = await _context.Antecedents.ToListAsync(),
                Allergies = await _context.Allergies.ToListAsync(),
                SelectedAntecedentIds = medicament.Antecedents.Select(a => a.AntecedentId).ToList() ?? new List<int>(),
                SelectedAllergieIds = medicament.Allergies.Select(a => a.AllergieId).ToList() ?? new List<int>()
            };

            return View(viewModel);
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MedicamentEditViewModel viewModel)
        {
            if (id != viewModel.Medicament.MedicamentId)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                viewModel.Antecedents = await _context.Antecedents.ToListAsync();
                viewModel.Allergies = await _context.Allergies.ToListAsync();
                return View(viewModel);
            }
            if (ModelState.IsValid)
            {
                try
                {
                    var medicament = await _context.Medicaments
                        .Include(m => m.Antecedents)
                        .Include(m => m.Allergies)
                        .FirstOrDefaultAsync(m => m.MedicamentId == id);


                    if (medicament == null)
                    {
                        return NotFound();
                    }

                    // Mise à jour des propriétés du médicament
                    medicament.Libelle_med = viewModel.Medicament.Libelle_med;
                    medicament.Contr_indication = viewModel.Medicament.Contr_indication;

                    // Mise à jour des allergies
                    medicament.Allergies.Clear();
                    if (viewModel.SelectedAllergieIds != null)
                    {
                        var selectedAllergies = await _context.Allergies
                            .Where(a => viewModel.SelectedAllergieIds.Contains(a.AllergieId))
                            .ToListAsync();
                        foreach (var allergie in selectedAllergies)
                        {
                            medicament.Allergies.Add(allergie);
                        }
                    }

                    // Mise à jour des antécédents
                    medicament.Antecedents.Clear();
                    if (viewModel.SelectedAntecedentIds != null)
                    {
                        var selectedAntecedents = await _context.Antecedents
                            .Where(a => viewModel.SelectedAntecedentIds.Contains(a.AntecedentId))
                            .ToListAsync();
                        foreach (var antecedent in selectedAntecedents)
                        {
                            medicament.Antecedents.Add(antecedent);
                        }
                    }
                    _context.Entry(medicament).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    ThrowException();
                    Console.WriteLine(ex.Message);
                    if (!MedecinExist(viewModel.Medicament.MedicamentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            // Si nous arrivons ici, quelque chose a échoué, réafficher le formulaire
            ThrowException();
            viewModel.Antecedents = await _context.Antecedents.ToListAsync();
            viewModel.Allergies = await _context.Allergies.ToListAsync();
            return View(viewModel);
        }

        private bool MedecinExist(int id)
        {
            return _context.Medicaments.Any(e => e.MedicamentId == id);
        }


        [HttpPost]
        public IActionResult ThrowException()
        {
            throw new Exception("Une exception s'est produite, nous testons la page d'exception pour les développeurs.");
        }

    }

}
