using APIwork.Models;
using COURS.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace COURS.Controllers
{
    public class PostContoller : Controller
    {
        public IActionResult Index()
        {
            ModelPostsPage model = new ModelPostsPage();
            string json = ApiHelper.Get("posts");
            model.ghfhg = "hsdhsfd";
            model.list = (List<Posts>)JsonConvert.DeserializeObject(json, typeof(List<Posts>));
            return View(model);
        }
        public IActionResult EditPost(int id)
        {
            ModelPostsPage model = new ModelPostsPage();
            model.posts = new Posts();
            if (id > 0)
            {
                string json = ApiHelper.GetId("posts", id);
                model.ghfhg = "hsdhsfd";
                model.posts = (Posts)JsonConvert.DeserializeObject(json, typeof(Posts));
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult EditPostPost(int id, ModelPostsPage model)
        {
            if (id > 0)
            {
                string json = ApiHelper.GetId("posts", id);
                Posts ro = (Posts)JsonConvert.DeserializeObject(json, typeof(Posts));
                ro.NamePost = model.posts.NamePost;
                string ser = JsonConvert.SerializeObject(ro);
                ApiHelper.Put(ser, "posts", id);
            }
            else
            {
                string ser = JsonConvert.SerializeObject(model.posts);
                ApiHelper.Post("posts", ser);
            }
            return RedirectToAction("Index", "PostContoller");
        }
        public IActionResult DeletePost(int id)
        {
            ApiHelper.Delete("posts", id);
            return RedirectToAction("Index", "PostContoller");
        }
    }
}
