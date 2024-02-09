using Microsoft.AspNetCore.Mvc;

namespace MusicShop.Controllers
{
    public class CosutomersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
