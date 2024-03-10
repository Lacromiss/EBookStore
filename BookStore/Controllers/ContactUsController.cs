using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class ContactUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
