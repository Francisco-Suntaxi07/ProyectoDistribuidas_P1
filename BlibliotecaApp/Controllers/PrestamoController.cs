using BlibliotecaApp.Models;
using BlibliotecaApp.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BlibliotecaApp.Controllers
{
    public class PrestamoController : Controller
    {

        private readonly IPrestamoService _prestamoService = new PrestamoService();
        

        // GET: Prestamo
        public async Task<ActionResult> MainPrestamo()
        {
            bool auxP = TempData["AuxP"] != null ? (bool)TempData["AuxP"] : true;

            List<PrestamoModel> prestamosList = await _prestamoService.ListaPrestamos();
            return View(prestamosList);
        }

        public async Task<ActionResult> FormularioPrestamo(string id)
        {
            var ASUX = id;
            PrestamoModel prestamoModel = new PrestamoModel();
            bool auxP = TempData["AuxP"] != null ? (bool)TempData["AuxP"] : true;


            if (id != null)
            {
                ViewBag.Acction = "Editar Prestamo";
                auxP = !auxP;
                TempData["AuxP"] = auxP;
                prestamoModel = await _prestamoService.BuscarPrestamo(id);
            }
            else
            {
                ViewBag.Acction = "Nuevo Prestamo";
                auxP = auxP;
                TempData["AuxP"] = auxP;
            }

            return View(prestamoModel);
        }


        [HttpPost]
        public async Task<ActionResult> GuardarPrestamo(string fecha_prestamo, string fecha_devolucion, string precio_prestamo, string multa_prestamo, PrestamoModel prestamoModel)
        {
            LibroModel libroModel = new LibroModel();
            ILibroService _libroService = new LibroService();

            bool response = false;
            bool auxP = TempData["AuxP"] != null ? (bool)TempData["AuxP"] : true;

            prestamoModel.fecha_prestamo = DateTime.Parse(fecha_prestamo);
            prestamoModel.fecha_devolucion = DateTime.Parse(fecha_devolucion);
            prestamoModel.precio_prestamo = 1.99m;
            //prestamoModel.precio_prestamo = Decimal.Parse(precio_prestamo);
            prestamoModel.multa_prestamo = 0.0m;
            //prestamoModel.multa_prestamo = Decimal.Parse(multa_prestamo);

            libroModel.id_libro = prestamoModel.id_libro;

            /*PrestamoModel prestamo = new PrestamoModel();
              prestamo.id_prestamo = "P006";
              prestamo.id_libro = "L001";
              prestamo.id_cliente = "1712345678";

              DateTime fecha = DateTime.Parse("2008/09/05");
              prestamo.fecha_prestamo = fecha;
              DateTime fecha1 = DateTime.Parse("2008/09/05");
              prestamo.fecha_devolucion = fecha1;
              prestamo.precio_prestamo = 1.99m;
              prestamo.multa_prestamo = 1.99m;
              prestamo.observaciones_prestamo = "ningunaa";
              response = await _prestamoService.GuardarPrestamo(prestamoModel);*/



            if (auxP)
            {
                response = await _prestamoService.GuardarPrestamo(prestamoModel);
            }
            else
            {
                response = await _prestamoService.EditarPrestamo(prestamoModel);
            }

            if (response)
            {
                libroModel = await _libroService.BuscarLibro(prestamoModel.id_libro);

                int auxCantidad = libroModel.cantidad_libro - 1;
                libroModel.cantidad_libro = auxCantidad;

                bool axuCOnulta = await _prestamoService.CantidadLibro(libroModel);
                
                return RedirectToAction("MainPrestamo");
            }
            else
            {
                return RedirectToAction("MainPrestamo");
            }
        }

        [HttpPost]
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



    }
}