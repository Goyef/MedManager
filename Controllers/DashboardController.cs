using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASPBookProject.Controllers
{
    public class DashboardController : Controller
    {
        // GET: DashboardController
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

    }
}
