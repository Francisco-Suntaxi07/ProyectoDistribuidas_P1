using BlibliotecaApp.Models;
using BlibliotecaApp.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BlibliotecaApp.Controllers
{
    public class EditorialController : Controller
    {
        private readonly IEditorialService _editorialService = new EditorialService();

        // GET: Editorial
        public async Task<ActionResult> MainEditorial()
        {
            bool AuxC = TempData["AuxC"] != null ? (bool)TempData["AuxC"] : true;

            List<EditorialModel> editorialList = await _editorialService.ListaEditoriales();
            return View(editorialList);
        }

        public async Task<ActionResult> FormularioEditorial(string id)
        {
            var ASUX = id;
            EditorialModel editorialModel = new EditorialModel();
            bool auxP = TempData["AuxP"] != null ? (bool)TempData["AuxP"] : true;


            if (id != null)
            {
                ViewBag.Acction = "Editar Editorial";
                auxP = !auxP;
                TempData["AuxP"] = auxP;
                editorialModel = await _editorialService.BuscarEditorial(id);
            }
            else
            {
                ViewBag.Acction = "Nueva Editorial";
                auxP = auxP;
                TempData["AuxP"] = auxP;
            }

            return View(editorialModel);
        }

        public async Task<ActionResult> GuardarEditorial(string id_editorial, string nombre_editorial, string direccion_editorial, EditorialModel editorialModel)
        {
            bool response = false;
            bool auxP = TempData["AuxP"] != null ? (bool)TempData["AuxP"] : true;

            if (auxP)
            {
                // Crear un nuevo editorial
                response = await _editorialService.GuardarEditorial(editorialModel);
            }
            else
            {
                // Editar editorial existente
                response = await _editorialService.EditarEditorial(editorialModel);
            }

            if (response)
            {
                return RedirectToAction("MainEditorial");
            }
            else
            {
                return RedirectToAction("MainEditorial");
            }
        }

        [HttpPost]
        public async Task<ActionResult> EliminarEditorial(string id)
        {
            var response = await _editorialService.EliminarEditorial(id);
            if (response)
            {
                return RedirectToAction("MainEditorial");
            }
            else
            {
                return RedirectToAction("MainEditorial");
            }
        }
    }
}