using Microsoft.AspNetCore.Mvc;

namespace Finexo.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
