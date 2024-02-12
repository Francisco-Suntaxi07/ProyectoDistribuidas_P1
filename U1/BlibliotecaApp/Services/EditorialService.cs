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
    public class EditorialService : IEditorialService
    {
        private static string _baseUrl;

        public EditorialService()
        {
            _baseUrl = ConfigurationManager.AppSettings["ApiUrlRecLibros"];
        }

        public async Task<List<EditorialModel>> ListaEditoriales()
        {
            List<EditorialModel> listaEditoriales = new List<EditorialModel>();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string uri = $"{_baseUrl}/Editoriales";
                    HttpResponseMessage response = await client.GetAsync(uri);

                    // Verificar si la solicitud fue exitosa (código de estado 200)
                    if (response.IsSuccessStatusCode)
                    {
                        var jsonResponse = await response.Content.ReadAsStringAsync();
                        listaEditoriales = JsonConvert.DeserializeObject<List<EditorialModel>>(jsonResponse);
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
            return listaEditoriales;

        }

        public async Task<EditorialModel> BuscarEditorial(string id)
        {
            EditorialModel editorialModel = new EditorialModel();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string uri = $"{_baseUrl}/Editoriales/{id}";
                    HttpResponseMessage response = await client.GetAsync(uri);

                    // Verificar si la solicitud fue exitosa (código de estado 200)
                    if (response.IsSuccessStatusCode)
                    {
                        var jsonResponse = await response.Content.ReadAsStringAsync();
                        editorialModel = JsonConvert.DeserializeObject<EditorialModel>(jsonResponse);
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
            return editorialModel;
        }

        public async Task<bool> GuardarEditorial(EditorialModel editorialModel)
        {
            bool auxResponse = false;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string uri = $"{_baseUrl}/Editoriales";

                    var content = new StringContent(JsonConvert.SerializeObject(editorialModel), Encoding.UTF8, "application/json");

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

        public async Task<bool> EditarEditorial(EditorialModel editorialModel)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string uri = $"{_baseUrl}/Editoriales/{editorialModel.id_editorial}";

                    var content = new StringContent(JsonConvert.SerializeObject(editorialModel), Encoding.UTF8, "application/json");

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

        public async Task<bool> EliminarEditorial(string id)
        {
            bool auxResponse = false;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string uri = $"{_baseUrl}/Editoriales/{id}";
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