using BibliotecaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaApp.Services
{
    internal interface IAutorService
    {
        Task<List<AutorModel>> ListaAutores();

        Task<AutorModel> BuscarAutor();

        Task<bool> GuardarAutor();

        Task<bool> EditarAutor();

        Task<bool> EliminarAutor();
    }
}
