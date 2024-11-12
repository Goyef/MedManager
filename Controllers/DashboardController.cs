using ASPBookProject.Data;
using ASPBookProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPBookProject.Controllers
{
    public class DashboardController : Controller
    {

        private readonly UserManager<Medecin> _userManager;
        private readonly ApplicationDbContext _context;
        
        public DashboardController(UserManager<Medecin> userManager, ApplicationDbContext context)
        {
            _context = context;
            _userManager = userManager;
        }
        // GET: DashboardController
        [Authorize]
        public async  Task<IActionResult> Index()
        {
            string medecinId = _userManager.GetUserId(User);
            Medecin med = _userManager.FindByIdAsync(medecinId).Result;
            if(med == null)
            {
                return RedirectToAction("Logout", "Dashboard");
            }
            List<Ordonnance> ordonnances = new List<Ordonnance>();
            ordonnances = await _context.Ordonnances
                                .Where(o => o.Date_debut <= DateTime.Now && o.Date_fin >= DateTime.Now)
                                .Include(o => o.Medecin) 
                                .Where(o => o.MedecinId == medecinId)
                                .Include(o =>o.Patient)
                                .ToListAsync();
            ordonnances.OrderByDescending(o => o.Patient.Nom_p);
            return View(ordonnances);
        }

    }
}
