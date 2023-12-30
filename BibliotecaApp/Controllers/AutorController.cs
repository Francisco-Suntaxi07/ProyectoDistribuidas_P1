using BibliotecaApp.Models;
using BibliotecaApp.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BibliotecaApp.Controllers
{
    public class AutorController : Controller
    {
        private readonly IAutorService _autorService = new AutorService();

        // GET: Autor
        public async Task<ActionResult> MainAutor()
        {
            List<AutorModel> autoresList = await _autorService.ListaAutores();
            ViewBag.Message = "Your contact page.";
            return View(autoresList);
        }
    }
}