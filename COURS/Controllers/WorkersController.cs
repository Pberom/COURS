using APIwork.Models;
using COURS.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace COURS.Controllers
{
    public class WorkersController : Controller
    {
        public IActionResult Index()
        {
            ModelWorkersPage model = new ModelWorkersPage();
            string json = ApiHelper.Get("workers");
            model.ghfhg = "hsdhsfd";
            model.list = (List<Workers>)JsonConvert.DeserializeObject(json, typeof(List<Workers>));
            return View(model);
        }
        public IActionResult EditRole(int id)
        {
            ModelWorkersPage model = new ModelWorkersPage();
            model.workers = new Workers();
            if (id > 0)
            {
                string json = ApiHelper.GetId("workers", id);
                model.ghfhg = "hsdhsfd";
                model.workers = (Workers)JsonConvert.DeserializeObject(json, typeof(Workers));
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult EditRolePost(int id, ModelWorkersPage model)
        {
            if (id > 0)
            {
                string json = ApiHelper.GetId("workers", id);
                Workers ro = (Workers)JsonConvert.DeserializeObject(json, typeof(Workers));
                ro.NameWorker = model.workers.NameWorker;
                string ser = JsonConvert.SerializeObject(ro);
                ApiHelper.Put(ser, "workers", id);
            }
            else
            {
                string ser = JsonConvert.SerializeObject(model.workers);
                ApiHelper.Post("workers", ser);
            }
            return RedirectToAction("Index", "Workers");
        }

        public IActionResult DeleteRole(int id)
        {
            ApiHelper.Delete("workers", id);
            return RedirectToAction("Index", "Workers");
        }
    }
}
