using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class BoomController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
