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
    public class ClienteService:IClienteService
    {
        private static string _baseUrl;
        public ClienteService()
        {
            // Acceder a la URI desde el archivo de configuración
            _baseUrl = ConfigurationManager.AppSettings["ApiUrlPrestamos"];
        }

        public async Task<List<ClienteModel>> ListaClientes()
        {
            List<ClienteModel> listaClientes = new List<ClienteModel>();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string uri = $"{_baseUrl}/customer/all";
                    HttpResponseMessage response = await client.GetAsync(uri);

                    // Verificar si la solicitud fue exitosa (código de estado 200)
                    if (response.IsSuccessStatusCode)
                    {
                        var jsonResponse = await response.Content.ReadAsStringAsync();
                        listaClientes = JsonConvert.DeserializeObject<List<ClienteModel>>(jsonResponse);
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
            return listaClientes;
        }

        public async Task<ClienteModel> BuscarCliente(string id)
        {
            ClienteModel clienteModel = new ClienteModel();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string uri = $"{_baseUrl}/customer/find/{id}";
                    HttpResponseMessage response = await client.GetAsync(uri);

                    // Verificar si la solicitud fue exitosa (código de estado 200)
                    if (response.IsSuccessStatusCode)
                    {
                        var jsonResponse = await response.Content.ReadAsStringAsync();
                        clienteModel = JsonConvert.DeserializeObject<ClienteModel>(jsonResponse);
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
            return clienteModel;
        }


        public async Task<bool> GuardarCliente(ClienteModel clienteModel)
        {
            bool auxResponse = false;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string uri = $"{_baseUrl}/customer/save";

                    var content = new StringContent(JsonConvert.SerializeObject(clienteModel), Encoding.UTF8, "application/json");

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

        

        public async Task<bool> EditarCliente(ClienteModel clienteModel)
        {
            bool auxResponse = false;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string uri = $"{_baseUrl}/customer/update/{clienteModel.id_cliente}";

                    var content = new StringContent(JsonConvert.SerializeObject(clienteModel), Encoding.UTF8, "application/json");

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

        public async Task<bool> EliminarCliente(string id)
        {
            bool auxResponse = false;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string uri = $"{_baseUrl}/customer/delete/{id}";
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