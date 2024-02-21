using Microsoft.AspNetCore.Mvc;

namespace TechOil.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
