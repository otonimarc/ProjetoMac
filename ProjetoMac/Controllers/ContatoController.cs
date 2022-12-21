using Microsoft.AspNetCore.Mvc;

namespace ProjetoMac.Controllers
{
    public class ContatoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
