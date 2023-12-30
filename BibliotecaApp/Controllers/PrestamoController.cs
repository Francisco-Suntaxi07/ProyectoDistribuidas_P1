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
            return View(prestamosList);
        }

        public async Task<ActionResult> BuscarPrestamo(string id)
        {
            PrestamoModel prestamoModel = new PrestamoModel();
            ViewBag.Acction = "Nuevo Prestamo";

            if (id != null || id != "")
            {
                prestamoModel = await _prestamoService.BuscarPrestamo(id);
                ViewBag.Acction = "Editar Prestamo";
            }

            return View(prestamoModel);
        }

        [HttpPost]
        public async Task<ActionResult> GuardarCambios(PrestamoModel prestamoModel)
        {
            bool response = false;

            if (prestamoModel.id_prestamo != null || prestamoModel.id_prestamo != "")
            {
                response = await _prestamoService.GuardarPrestamo(prestamoModel);
            }
            else
            {
                response = await _prestamoService.EditarPrestamo(prestamoModel);
            } 
            
            if (response)
            {
                return RedirectToAction("MainPrestamo");
            }
            else
            {
                return RedirectToAction("MainPrestamo");
            }

        }

        [HttpGet]
        public async Task<ActionResult> EliminarPrestamo(string id) 
        {
            var response = await _prestamoService.EliminarPrestamo(id);
            if (response)
            {
                return RedirectToAction("MainPrestamo");
            }
            else
            {
                return RedirectToAction("MainPrestamo");
            }
        }


        public async Task<ActionResult> GuardarPrestamo(string id)
        {
            PrestamoModel prestamoModel = new PrestamoModel();
            ViewBag.Acction = "Nuevo Prestamo";

            if (id != null || id != "")
            {
                prestamoModel = await _prestamoService.BuscarPrestamo(id);
                ViewBag.Acction = "Editar Prestamo";
            }

            return View(prestamoModel);
        }
    }
}