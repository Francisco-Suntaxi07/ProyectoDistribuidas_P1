using BlibliotecaApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlibliotecaApp.Services
{
    public class GeneroService : IGeneroService
    {
        private static string _baseUrl;

        public GeneroService()
        {
            _baseUrl = ConfigurationManager.AppSettings["ApiUrlRecLibros"];
        }

        public async Task<List<GeneroModel>> ListaGeneros()
        {
            List<GeneroModel> listaGeneros = new List<GeneroModel>();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string uri = $"{_baseUrl}/Generos";
                    HttpResponseMessage response = await client.GetAsync(uri);

                    // Verificar si la solicitud fue exitosa (código de estado 200)
                    if (response.IsSuccessStatusCode)
                    {
                        var jsonResponse = await response.Content.ReadAsStringAsync();
                        listaGeneros = JsonConvert.DeserializeObject<List<GeneroModel>>(jsonResponse);
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
            return listaGeneros;

        }

        public async Task<GeneroModel> BuscarGenero(string id)
        {
            GeneroModel generoModel = new GeneroModel();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string uri = $"{_baseUrl}/Generos/{id}";
                    HttpResponseMessage response = await client.GetAsync(uri);

                    // Verificar si la solicitud fue exitosa (código de estado 200)
                    if (response.IsSuccessStatusCode)
                    {
                        var jsonResponse = await response.Content.ReadAsStringAsync();
                        generoModel = JsonConvert.DeserializeObject<GeneroModel>(jsonResponse);
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
            return generoModel;
        }

        public async Task<bool> GuardarGenero(GeneroModel generoModel)
        {
            bool auxResponse = false;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string uri = $"{_baseUrl}/Generos";

                    var content = new StringContent(JsonConvert.SerializeObject(generoModel), Encoding.UTF8, "application/json");

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

        public async Task<bool> EditarGenero(GeneroModel generoModel)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string uri = $"{_baseUrl}/Autores/{generoModel.id_genero}";

                    var content = new StringContent(JsonConvert.SerializeObject(generoModel), Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PutAsync(uri, content);

                    // Verificar si la solicitud fue exitosa (código de estado 200)
                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    else
                    {
                        Console.WriteLine($"Error en la solicitud. Código de estado: {response.StatusCode}");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la solicitud: {ex.Message}");
                return false;
            }
        }



        public async Task<bool> EliminarGenero(string id)
        {
            bool auxResponse = false;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string uri = $"{_baseUrl}/Generos/{id}";
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