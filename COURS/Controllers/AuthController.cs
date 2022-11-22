using APIwork.Models;
using COURS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.CodeAnalysis;
using Newtonsoft.Json;

namespace COURS.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            ModelRolesPage model = new ModelRolesPage();
            string json = ApiHelper.Get("roles");
            model.ghfhg = "hsdhsfd";
            model.list = (List<Role>)JsonConvert.DeserializeObject(json, typeof(List<Role>));        
            return View(model);
        }

        public IActionResult EditRole(int id)
        {
            ModelRolesPage model = new ModelRolesPage();
            model.role = new Role();
            if(id>0)
            {
                string json = ApiHelper.GetId("roles", id);
                model.ghfhg = "hsdhsfd";
                model.role = (Role)JsonConvert.DeserializeObject(json, typeof(Role));
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult EditRolePost(int id, ModelRolesPage model)
        {
            if(id > 0)
            {
                string json = ApiHelper.GetId("roles", id);
                Role ro = (Role)JsonConvert.DeserializeObject(json, typeof(Role));
                ro.NameRole = model.role.NameRole;
                string ser = JsonConvert.SerializeObject(ro);
                ApiHelper.Put(ser, "roles", id);
            }
            else
            {
                string ser = JsonConvert.SerializeObject(model.role);
                ApiHelper.Post("roles", ser);
            }
            return RedirectToAction("Index","Auth");
        }

        public IActionResult DeleteRole(int id)
        {
            ApiHelper.Delete("roles", id);
            return RedirectToAction("Index", "Auth");
        }
    }
}
