using Microsoft.AspNetCore.Mvc;

namespace MvcNetCorePichonCSRF.Controllers
{
    public class TiendaController : Controller
    {
        public IActionResult Productos()
        {
            // Si el usuario no esta validado todavía, lo llevamos a denegado
            if(HttpContext.Session.GetString("USUARIO") == null)
            {
                return RedirectToAction("Denied", "Managed");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Productos(string direccion, string[] producto)
        {

        }
    }
}
