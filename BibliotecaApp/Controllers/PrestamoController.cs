using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BibliotecaApp.Controllers.Prestamos
{
    public class PrestamoController : Controller
    {
        // GET: Prestamo
        public ActionResult MainPrestamo()
        {
            return View();
        }
    }
}