using Microsoft.AspNetCore.Mvc;

namespace COURS.Controllers
{
    public class RegController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
