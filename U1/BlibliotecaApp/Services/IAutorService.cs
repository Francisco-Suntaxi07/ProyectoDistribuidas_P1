using BlibliotecaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlibliotecaApp.Services
{
    internal interface IAutorService
    {
        Task<List<AutorModel>> ListaAutores();

        Task<AutorModel> BuscarAutor(string id);

        Task<bool> GuardarAutor(AutorModel autorModel);

        Task<bool> EditarAutor(AutorModel autorModel);

        Task<bool> EliminarAutor(string id);
    }
}
