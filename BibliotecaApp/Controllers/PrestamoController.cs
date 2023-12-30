using BibliotecaApp.Models;
using BibliotecaApp.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BibliotecaApp.Controllers.Prestamos
{
    public class PrestamoController : Controller
    {
        private readonly IPrestamoService _prestamoService = new PrestamoService();

        public async Task<ActionResult> MainPrestamo()
        {
            List<PrestamoModel> prestamosList = await _prestamoService.ListaPrestamos();
            ViewBag.Message = "Your contact page.";
            return View(prestamosList);
        }

        public async Task<ActionResult> Form()
        {
            List<PrestamoModel> prestamosList = await _prestamoService.ListaPrestamos();
            ViewBag.Message = "Your contact page.";
            return View(prestamosList);
        }
    }
}