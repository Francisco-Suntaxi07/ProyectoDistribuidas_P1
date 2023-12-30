using BibliotecaApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace BibliotecaApp.Services
{
    public class AutorService : IAutorService
    {
        private static string _baseUrl;

        public AutorService()
        {
            // Acceder a la URI desde el archivo de configuración
            _baseUrl = ConfigurationManager.AppSettings["ApiUrlAutor"];
        }

        public Task<AutorModel> BuscarAutor()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> EditarAutor()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> EliminarAutor()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> GuardarAutor()
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<AutorModel>> ListaAutores()
        {
            List<AutorModel> listaAutores = new List<AutorModel>();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string uri = $"{_baseUrl}/Autores";
                    HttpResponseMessage response = await client.GetAsync(uri);

                    // Verificar si la solicitud fue exitosa (código de estado 200)
                    if (response.IsSuccessStatusCode)
                    {
                        var jsonResponse = await response.Content.ReadAsStringAsync();
                        listaAutores = JsonConvert.DeserializeObject<List<AutorModel>>(jsonResponse);
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
            return listaAutores;
        }
    }
}