using BlibliotecaApp.Models;
using BlibliotecaApp.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BlibliotecaApp.Controllers
{
    public class AutorController : Controller
    {
        private readonly IAutorService _autorService = new AutorService();

        // GET: Autor
        public async Task<ActionResult> MainAutor()
        {
            bool auxP = TempData["AuxP"] != null ? (bool)TempData["AuxP"] : true;

            List<AutorModel> autorList = await _autorService.ListaAutores();
            return View(autorList);
        }

        public async Task<ActionResult> FormularioAutor(string id)
        {
            var ASUX = id;
            AutorModel autorModel = new AutorModel();
            bool auxP = TempData["AuxP"] != null ? (bool)TempData["AuxP"] : true;


            if (id != null)
            {
                ViewBag.Acction = "Editar Autor";
                auxP = !auxP;
                TempData["AuxP"] = auxP;
                autorModel = await _autorService.BuscarAutor(id);
            }
            else
            {
                ViewBag.Acction = "Nuevo Autor";
                auxP = auxP;
                TempData["AuxP"] = auxP;
            }

            return View(autorModel);
        }


        [HttpPost]
        public async Task<ActionResult> GuardarAutor(string id_autor, string nombre_autor, string nacionalidad_autor, AutorModel autorModel)
        {
            bool response = false;
            bool auxP = TempData["AuxP"] != null ? (bool)TempData["AuxP"] : true;

            if (auxP)
            {
                // Crear un nuevo autor
                response = await _autorService.GuardarAutor(autorModel);
            }
            else
            {
                // Editar autor existente
                response = await _autorService.EditarAutor(autorModel);
            }

            if (response)
            {
                return RedirectToAction("FormularioAutor");
            }
            else
            {
                return RedirectToAction("FormularioAutor");
            }
        }


        [HttpPost]
        public async Task<ActionResult> EliminarAutor(string id)
        {
            var response = await _autorService.EliminarAutor(id);
            if (response)
            {
                return RedirectToAction("MainAutor");
            }
            else
            {
                return RedirectToAction("MainAutor");
            }
        }
    }
}