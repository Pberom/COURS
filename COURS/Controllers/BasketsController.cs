using APIwork.Models;
using COURS.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace COURS.Controllers
{
    public class BasketsController : Controller
    {
        public IActionResult Index()
        {
            ModelBasketsPage model = new ModelBasketsPage();
            string json = ApiHelper.Get("Baskets");
            model.ghfhg = "hsdhsfd";
            model.list = (List<Basket>)JsonConvert.DeserializeObject(json, typeof(List<Basket>));
            return View(model);
        }
        public IActionResult EditPost(int id)
        {
            ModelBasketsPage model = new ModelBasketsPage();
            model.basket = new Basket();
            if (id > 0)
            {
                string json = ApiHelper.GetId("Baskets", id);
                model.ghfhg = "hsdhsfd";
                model.basket = (Basket)JsonConvert.DeserializeObject(json, typeof(Basket));
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult EditBasketPost(int id, ModelBasketsPage model)
        {
            if (id > 0)
            {
                string json = ApiHelper.GetId("Baskets", id);
                Basket ro = (Basket)JsonConvert.DeserializeObject(json, typeof(Basket));
                ro.ProductId = model.basket.ProductId;
                string ser = JsonConvert.SerializeObject(ro);
                ApiHelper.Put(ser, "Baskets", id);
            }
            else
            {
                string ser = JsonConvert.SerializeObject(model.basket);
                ApiHelper.Post("Baskets", ser);
            }
            return RedirectToAction("Index", "BasketsContoller");
        }
        public IActionResult DeletePost(int id)
        {
            ApiHelper.Delete("Baskets", id);
            return RedirectToAction("Index", "BasketsContoller");
        }
    }
}
