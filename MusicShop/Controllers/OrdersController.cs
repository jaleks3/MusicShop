using Microsoft.AspNetCore.Mvc;

namespace MusicShop.Controllers
{
    public class OrdersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
