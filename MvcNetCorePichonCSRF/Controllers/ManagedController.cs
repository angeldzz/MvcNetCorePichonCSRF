using Microsoft.AspNetCore.Mvc;

namespace MvcNetCorePichonCSRF.Controllers
{
    public class ManagedController : Controller
    {
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LogIn(string usuario, string password)
        {
            if (usuario.ToLower() == "admin" && password == "12345")
            {
                HttpContext.Session.SetString("USUARIO", usuario);
                return RedirectToAction("Productos", "Tienda");
            }
            else
            {
                ViewData["MENSAJE"] = "Usuario/Password incorrectos";
                return View();
            }
        }
        public IActionResult Denied()
        {
            return View();
        }
    }
}
