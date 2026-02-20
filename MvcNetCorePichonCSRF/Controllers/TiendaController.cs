using Microsoft.AspNetCore.Mvc;

namespace MvcNetCorePichonCSRF.Controllers
{
    public class TiendaController : Controller
    {
        public IActionResult Productos()
        {
            // Si el usuario no esta validado todavía, lo llevamos a denegado
            if (HttpContext.Session.GetString("USUARIO") == null)
            {
                return RedirectToAction("Denied", "Managed");
            }
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Productos(string direccion, string[] producto)
        {
            if (HttpContext.Session.GetString("USUARIO") == null)
            {
                return RedirectToAction("Denied", "Managed");
            }
            else
            {
                // Lo llevamos a pedido final, enviamos la direccion y los productos
                TempData["PRODUCTOS"] = producto;
                TempData["DIRECCION"] = direccion;
                return RedirectToAction("PedidoFinal");
            }
        }

        public IActionResult PedidoFinal()
        {
            // Recuperamos los productos
            string[] productos = TempData["PRODUCTOS"] as string[];
            ViewData["DIRECCION"] = TempData["DIRECCION"];
            return View(productos);
        }
    }
}
