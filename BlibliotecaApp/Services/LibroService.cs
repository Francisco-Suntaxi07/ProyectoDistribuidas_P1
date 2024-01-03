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
    public class LibroService : ILibroService
    {
        private static string _baseUrl;

        public LibroService()
        {
            _baseUrl = ConfigurationManager.AppSettings["ApiUrlRecLibros"];
        }

        public async Task<List<LibroModel>> ListaLibros()
        {
            List<LibroModel> listaLibros = new List<LibroModel>();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string uri = $"{_baseUrl}/Libros";
                    HttpResponseMessage response = await client.GetAsync(uri);

                    // Verificar si la solicitud fue exitosa (código de estado 200)
                    if (response.IsSuccessStatusCode)
                    {
                        var jsonResponse = await response.Content.ReadAsStringAsync();
                        listaLibros = JsonConvert.DeserializeObject<List<LibroModel>>(jsonResponse);
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
            return listaLibros;

        }

        public async Task<LibroModel> BuscarLibro(string id)
        {
            LibroModel libroModel = new LibroModel();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string uri = $"{_baseUrl}/Libros/{id}";
                    HttpResponseMessage response = await client.GetAsync(uri);

                    // Verificar si la solicitud fue exitosa (código de estado 200)
                    if (response.IsSuccessStatusCode)
                    {
                        var jsonResponse = await response.Content.ReadAsStringAsync();
                        libroModel = JsonConvert.DeserializeObject<LibroModel>(jsonResponse);
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
            return libroModel;
        }

        public async Task<bool> GuardarLibro(LibroModel libroModel)
        {
            bool auxResponse = false;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string uri = $"{_baseUrl}/Libros";

                    var content = new StringContent(JsonConvert.SerializeObject(libroModel), Encoding.UTF8, "application/json");

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

        public async Task<bool> EditarLibro(LibroModel libroModel)
        {
            bool auxResponse = false;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string uri = $"{_baseUrl}/Libros/{libroModel.id_libro}";

                    var content = new StringContent(JsonConvert.SerializeObject(libroModel), Encoding.UTF8, "application/json");

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

        public async Task<bool> EliminarLibro(string id)
        {
            bool auxResponse = false;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string uri = $"{_baseUrl}/Libros/{id}";
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