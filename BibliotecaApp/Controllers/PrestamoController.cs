using BibliotecaApp.Models;
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
        // GET: Prestamo
        public async Task< ActionResult> MainPrestamo()
        {
            List<PrestamoModel> listaPrestamos = new List<PrestamoModel>();
            HttpClient client = new HttpClient();
            string uri = "https://localhost:5001/api/loan/all";
            HttpResponseMessage response = await client.GetAsync(uri);
            var jsonResponse = await response.Content.ReadAsStringAsync();
            listaPrestamos = JsonConvert.DeserializeObject<List<PrestamoModel>>(jsonResponse);

            Console.WriteLine($"Error en la solicitud. Código de estado: {response.StatusCode}");
            return View();
        }
    }
}