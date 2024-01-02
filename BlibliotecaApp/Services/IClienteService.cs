using BlibliotecaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlibliotecaApp.Services
{
    internal interface IClienteService
    {
        Task<List<ClienteModel>> ListaClientes();

        Task<ClienteModel> BuscarCliente(string id);

        Task<bool> GuardarCliente(ClienteModel clienteModel);

        Task<bool> EditarCliente(ClienteModel clienteModel);

        Task<bool> EliminarCliente(string id);
    }
}
