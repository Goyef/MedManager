using ASPBookProject.Data;
using ASPBookProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASPBookProject.ViewModels;

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
                                .Include(o => o.Medecin) 
                                .Where(o => o.MedecinId == medecinId)
                                .Include(o =>o.Patient)
                                .ToListAsync();
             var ordonnancesCurrent = ordonnances
                    .Where(o => o.Date_debut <= DateTime.Now.Date && o.Date_fin >= DateTime.Now.Date)
                    .OrderByDescending(o => o.Patient.Nom_p)
                    .ToList();
            
            ordonnances.OrderByDescending(o => o.Patient.Nom_p);
           

             var recentPatients = ordonnances
         .Where(o => o.Date_debut >= DateTime.Now.AddDays(-30))
         .Select(o => o.Patient)
         .ToHashSet().ToList();

         var viewModel = new DashboardViewModel
    {
        Ordonnances = ordonnancesCurrent,
        RecentPatients = recentPatients
    };

    return View(viewModel);

    }}
}
