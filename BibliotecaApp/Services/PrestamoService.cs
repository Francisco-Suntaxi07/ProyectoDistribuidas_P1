using BibliotecaApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace BibliotecaApp.Services
{
    public class PrestamoService: IPrestamoService
    {
        private static string _baseUrl;

        public PrestamoService()
        {
            // Acceder a la URI desde el archivo de configuración
            _baseUrl = ConfigurationManager.AppSettings["ApiUrlPrestamos"];
        }

        public async Task<List<PrestamoModel>> ListaPrestamos()
        {
            List<PrestamoModel> listaPrestamos = new List<PrestamoModel>();

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string uri = $"{_baseUrl}/loan/all";
                    HttpResponseMessage response = await client.GetAsync(uri);

                    // Verificar si la solicitud fue exitosa (código de estado 200)
                    if (response.IsSuccessStatusCode)
                    {
                        var jsonResponse = await response.Content.ReadAsStringAsync();
                        listaPrestamos = JsonConvert.DeserializeObject<List<PrestamoModel>>(jsonResponse);
                    }
                    else
                    {
                        Console.WriteLine($"Error en la solicitud. Código de estado: {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la solicitud: {ex.Message}");
            }
            return listaPrestamos;

        }

        public Task<PrestamoModel> BuscarPrestamo()
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditarPrestamo()
        {
            throw new NotImplementedException();
        }

        public Task<bool> EliminarPrestamo()
        {
            throw new NotImplementedException();
        }

        public Task<bool> GuardarPrestamo()
        {
            throw new NotImplementedException();
        }

        
    }
}