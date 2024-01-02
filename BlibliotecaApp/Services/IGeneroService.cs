using BlibliotecaApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlibliotecaApp.Services
{
    internal interface IGeneroService
    {
        Task<List<GeneroModel>> ListaGeneros();

        Task<GeneroModel> BuscarGenero(string id);

        Task<bool> GuardarGenero(GeneroModel generoModel);

        Task<bool> EditarGenero(GeneroModel generoModel);

        Task<bool> EliminarGenero(string id);
    }
}
