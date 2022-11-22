using APIwork.Models;
using COURS.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace COURS.Controllers
{
    public class StatusController : Controller
    {
        public IActionResult Index()
        {
            ModelStatusPage model = new ModelStatusPage();
            string json = ApiHelper.Get("status");
            model.ghfhg = "hsdhsfd";
            model.list = (List<Status>)JsonConvert.DeserializeObject(json, typeof(List<Status>));
            return View(model);
        }
    }
}
