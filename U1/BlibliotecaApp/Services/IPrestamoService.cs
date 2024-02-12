using BlibliotecaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlibliotecaApp.Services
{
    internal interface IPrestamoService
    {
        Task<List<PrestamoModel>> ListaPrestamos();

        Task<PrestamoModel> BuscarPrestamo(string id);

        Task<bool> GuardarPrestamo(PrestamoModel prestamoModel);

        Task<bool> EditarPrestamo(PrestamoModel prestamoModel);

        Task<bool> EliminarPrestamo(string id);

        Task<bool> CantidadLibro(LibroModel libroModel);
    }
}
