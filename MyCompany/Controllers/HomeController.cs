using Microsoft.AspNetCore.Mvc;

namespace MyCompany.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
