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

            List<EditorialModel> editorialesList = await _editorialService.ListaEditoriales();
            return View(editorialesList);
        }

        public async Task<ActionResult> FormularioEditorial(string id)
        {
            var ASUX = id;
            EditorialModel editorialModel = new EditorialModel();
            bool auxP = TempData["AuxP"] != null ? (bool)TempData["AuxP"] : true;


            if (id != null)
            {
                ViewBag.Acction = "Editar Autor";
                auxP = !auxP;
                TempData["AuxP"] = auxP;
                editorialModel = await _editorialService.BuscarEditorial(id);
            }
            else
            {
                ViewBag.Acction = "Nuevo Autor";
                auxP = auxP;
                TempData["AuxP"] = auxP;
            }

            return View(editorialModel);
        }

        /*[HttpPost]
        public async Task<ActionResult> GuardarEditorial(string id_editorial, string nombre_editorial, string direccion_editorial, EditorialModel editorialModel)
        {
            bool response = false;
            bool AuxC = TempData["AuxC"] != null ? (bool)TempData["AuxC"] : true;
            var auxAAAA = AuxC;

            if (AuxC)
            {
                response = await _editorialService.GuardarEditorial(editorialModel);
            }
            else
            {
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
        }*/

        [HttpPost]
        public async Task<ActionResult> GuardarEditorial(string id_editorial, string nombre_editorial, string direccion_editorial, EditorialModel editorialModel)
        {
            bool response = false;
            bool isEditMode = !string.IsNullOrEmpty(editorialModel.id_editorial);

            if (isEditMode)
            {
                response = await _editorialService.EditarEditorial(editorialModel);
            }
            else
            {
                response = await _editorialService.GuardarEditorial(editorialModel);
            }

            if (response)
            {
                return RedirectToAction("MainEditorial");
            }
            else
            {
                // Manejo de errores si la operación falla
                return View("FormularioEditorial", editorialModel);
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