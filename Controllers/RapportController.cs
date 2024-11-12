using ASPBookProject.Data;
using ASPBookProject.Models;
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
        // GET: RapportController
        public async Task<ActionResult> Index()
        {
            // string medecinId = _userManager.GetUserId(User);
            // List<Ordonnance> ordonnances = new List<Ordonnance>();
            // ordonnances = await _context.Ordonnances
            //                     .Include(o => o.Medecin) 
            //                     .Where(o => o.MedecinId == medecinId)
            //                     .Include(o =>o.Patient)
            //                     .Include(o => o.Medicaments)
            //                     .ToListAsync();
            List<Medicament> medicaments = new List<Medicament>();
            medicaments = await _context.Medicaments
                                .ToListAsync();
            medicaments.OrderByDescending(o => o.compteur);
            return View(medicaments);

        }

    }
}
