using Microsoft.AspNetCore.Mvc;

namespace TechOil.Controllers
{
    public class ProyectoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
