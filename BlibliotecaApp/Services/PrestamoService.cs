using BlibliotecaApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BlibliotecaApp.Services
{
    public class PrestamoService:IPrestamoService
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

        public async Task<PrestamoModel> BuscarPrestamo(string id)
        {
            PrestamoModel prestamoModel = new PrestamoModel();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string uri = $"{_baseUrl}/loan/find/{id}";
                    HttpResponseMessage response = await client.GetAsync(uri);

                    // Verificar si la solicitud fue exitosa (código de estado 200)
                    if (response.IsSuccessStatusCode)
                    {
                        var jsonResponse = await response.Content.ReadAsStringAsync();
                        prestamoModel = JsonConvert.DeserializeObject<PrestamoModel>(jsonResponse);
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
            return prestamoModel;
        }

        public async Task<bool> GuardarPrestamo(PrestamoModel prestamoModel)
        {
            bool auxResponse = false;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string uri = $"{_baseUrl}/loan/save";

                    var content = new StringContent(JsonConvert.SerializeObject(prestamoModel), Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(uri, content);

                    // Verificar si la solicitud fue exitosa (código de estado 200)
                    if (response.IsSuccessStatusCode)
                    {
                        auxResponse = true;
                    }
                    else
                    {
                        auxResponse = false;
                        Console.WriteLine($"Error en la solicitud. Código de estado: {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la solicitud: {ex.Message}");
            }
            return auxResponse;
        }

        public async Task<bool> EditarPrestamo(PrestamoModel prestamoModel)
        {
            bool auxResponse = false;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string uri = $"{_baseUrl}/loan/update/{prestamoModel.id_prestamo}";

                    var content = new StringContent(JsonConvert.SerializeObject(prestamoModel), Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PutAsync(uri, content);

                    // Verificar si la solicitud fue exitosa (código de estado 200)
                    if (response.IsSuccessStatusCode)
                    {
                        auxResponse = true;
                    }
                    else
                    {
                        auxResponse = false;
                        Console.WriteLine($"Error en la solicitud. Código de estado: {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la solicitud: {ex.Message}");
            }
            return auxResponse;
        }

        public async Task<bool> EliminarPrestamo(string id)
        {
            bool auxResponse = false;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string uri = $"{_baseUrl}/loan/delete/{id}";
                    HttpResponseMessage response = await client.DeleteAsync(uri);

                    // Verificar si la solicitud fue exitosa (código de estado 200)
                    if (response.IsSuccessStatusCode)
                    {
                        auxResponse = true;
                    }
                    else
                    {
                        auxResponse = true;
                        Console.WriteLine($"Error en la solicitud. Código de estado: {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la solicitud: {ex.Message}");
            }
            return auxResponse;
        }

    }
}