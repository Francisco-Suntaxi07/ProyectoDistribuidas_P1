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

        Task<AutorModel> BuscarPrestamo();

        Task<bool> GuardarPrestamo();

        Task<bool> EditarPrestamo();

        Task<bool> EliminarPrestamo();
    }
}
