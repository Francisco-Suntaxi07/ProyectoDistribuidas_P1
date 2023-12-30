using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BibliotecaApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult MainPrestamo()
        {
            // Redirige a la acción "Index" del controlador "OtraPagina"
            //ViewBag.Message = "Your contact page.";
            return RedirectToAction("MainPrestamo", "Prestamo");
        }
    }
}