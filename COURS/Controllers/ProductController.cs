using APIwork.Models;
using COURS.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace COURS.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            ModelProductPage model = new ModelProductPage();
            string json = ApiHelper.Get("Products");
            model.ghfhg = "hsdhsfd";
            model.list = (List<Product>)JsonConvert.DeserializeObject(json, typeof(List<Product>));
            return View(model);
        }
        public IActionResult EditProduct(int id)
        {
            ModelProductPage model = new ModelProductPage();
            model.product = new Product();
            if (id > 0)
            {
                string json = ApiHelper.GetId("Products", id);
                model.ghfhg = "hsdhsfd";
                model.product = (Product)JsonConvert.DeserializeObject(json, typeof(Product));
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult EditProductPost(int id, ModelProductPage model)
        {
            if (id > 0)
            {
                string json = ApiHelper.GetId("Products", id);
                Product ro = (Product)JsonConvert.DeserializeObject(json, typeof(Product));
                ro.NameProduct = model.product.NameProduct;
                string ser = JsonConvert.SerializeObject(ro);
                ApiHelper.Put(ser, "Products", id);
            }
            else
            {
                string ser = JsonConvert.SerializeObject(model.product);
                ApiHelper.Post("Products", ser);
            }
            return RedirectToAction("Index", "ProductContoller");
        }
        public IActionResult DeleteProduct(int id)
        {
            ApiHelper.Delete("Products", id);
            return RedirectToAction("Index", "ProductContoller");
        }
    }
}
