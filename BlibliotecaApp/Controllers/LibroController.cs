using BlibliotecaApp.Models;
using BlibliotecaApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BlibliotecaApp.Controllers
{
    public class LibroController : Controller
    {
        private readonly ILibroService _libroService = new LibroService();
        // GET: Libro
        public async Task<ActionResult> MainLibro()
        {
            bool auxP = TempData["AuxP"] != null ? (bool)TempData["AuxP"] : true;

            List<LibroModel> libroList = await _libroService.ListaLibros();
            return View(libroList);
        }

        public async Task<ActionResult> FormularioLibro(string id)
        {
            var ASUX = id;
            LibroModel libroModel = new LibroModel();
            bool auxP = TempData["AuxP"] != null ? (bool)TempData["AuxP"] : true;


            if (id != null)
            {
                ViewBag.Acction = "Editar Libro";
                auxP = !auxP;
                TempData["AuxP"] = auxP;
                libroModel = await _libroService.BuscarLibro(id);
            }
            else
            {
                ViewBag.Acction = "Nuevo Libro";
                auxP = auxP;
                TempData["AuxP"] = auxP;
            }

            return View(libroModel);
        }


        [HttpPost]
        public async Task<ActionResult> GuardarLibro(LibroModel libroModel)
        {
            bool response = false;
            bool auxP = TempData["AuxP"] != null ? (bool)TempData["AuxP"] : true;

            if (auxP)
            {
                // Crear un nuevo autor
                response = await _libroService.GuardarLibro(libroModel);
            }
            else
            {
                // Editar autor existente
                response = await _libroService.EditarLibro(libroModel);
            }

            if (response)
            {
                return RedirectToAction("MainLibro");
            }
            else
            {
                return RedirectToAction("MainLibro");
            }
        }


        [HttpPost]
        public async Task<ActionResult> EliminarLibro(string id)
        {
            var response = await _libroService.EliminarLibro(id);
            if (response)
            {
                return RedirectToAction("MainLibro");
            }
            else
            {
                return RedirectToAction("MainLibro");
            }
        }
    }
}