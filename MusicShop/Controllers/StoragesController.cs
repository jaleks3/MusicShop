using Microsoft.AspNetCore.Mvc;

namespace MusicShop.Controllers
{
    public class StoragesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
