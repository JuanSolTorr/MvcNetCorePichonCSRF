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
            if(HttpContext.Session.GetString("USUARIO") == null)
            {
                return RedirectToAction("Denied", "Managed");
            }
            else
            {
                // Lo llevamos a pedido final, enviamos la direccion y los productos
                ViewData["PRODUCTOS"] = producto;
                ViewData["DIRECCION"] = direccion;
                return RedirectToAction("PedidoFinal");
            }
        }

        public IActionResult PedidoFinal()
        {
            // Recuperamos los productos
            string[] productos = ViewData["PRODUCTOS"] as string[];
            return View(productos);
        }
    }
}
