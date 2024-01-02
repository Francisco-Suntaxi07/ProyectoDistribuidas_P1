using BlibliotecaApp.Models;
using BlibliotecaApp.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BlibliotecaApp.Controllers
{
    public class GeneroController : Controller
    {
        private readonly IGeneroService _generoService = new GeneroService();

        // GET: Genero
        public async Task<ActionResult> MainGenero()
        {
            bool auxP = TempData["AuxP"] != null ? (bool)TempData["AuxP"] : true;

            List<GeneroModel> generoList = await _generoService.ListaGeneros();
            return View(generoList);
        }

        public async Task<ActionResult> FormularioGenero(string id)
        {
            var ASUX = id;
            GeneroModel generoModel = new GeneroModel();
            bool auxP = TempData["AuxP"] != null ? (bool)TempData["AuxP"] : true;


            if (id != null)
            {
                ViewBag.Acction = "Editar Genero";
                auxP = !auxP;
                TempData["AuxP"] = auxP;
                generoModel = await _generoService.BuscarGenero(id);
            }
            else
            {
                ViewBag.Acction = "Nuevo Genero";
                auxP = auxP;
                TempData["AuxP"] = auxP;
            }

            return View(generoModel);
        }


        [HttpPost]
        public async Task<ActionResult> GuardarGenero(string id_genero, string nombre_genero, string descripcion_genero, GeneroModel generoModel)
        {
            bool response = false;
            bool auxP = TempData["AuxP"] != null ? (bool)TempData["AuxP"] : true;

            if (auxP)
            {
                // Crear un nuevo autor
                response = await _generoService.GuardarGenero(generoModel);
            }
            else
            {
                // Editar autor existente
                response = await _generoService.EditarGenero(generoModel);
            }

            if (response)
            {
                return RedirectToAction("MainGenero");
            }
            else
            {
                return RedirectToAction("MainGenero");
            }
        }


        [HttpPost]
        public async Task<ActionResult> EliminarGenero(string id)
        {
            var response = await _generoService.EliminarGenero(id);
            if (response)
            {
                return RedirectToAction("MainGenero");
            }
            else
            {
                return RedirectToAction("MainGenero");
            }
        }
    }
}