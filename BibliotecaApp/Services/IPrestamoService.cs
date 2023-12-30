using BibliotecaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaApp.Services
{
    internal interface IPrestamoService
    {
        Task<List<PrestamoModel>> ListaPrestamos();
      
        Task<PrestamoModel> BuscarPrestamo();

        Task<bool> GuardarPrestamo();

        Task<bool> EditarPrestamo();

        Task<bool> EliminarPrestamo();

    }
}
