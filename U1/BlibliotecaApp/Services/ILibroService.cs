using BlibliotecaApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlibliotecaApp.Services
{
    internal interface ILibroService
    {
        Task<List<LibroModel>> ListaLibros();

        Task<LibroModel> BuscarLibro(string id);

        Task<bool> GuardarLibro(LibroModel libroModel);

        Task<bool> EditarLibro(LibroModel libroModel);

        Task<bool> EliminarLibro(string id);
    }
}
