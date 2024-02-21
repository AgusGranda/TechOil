using Microsoft.AspNetCore.Mvc;

namespace TechOil.Controllers
{
    public class ServicioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
