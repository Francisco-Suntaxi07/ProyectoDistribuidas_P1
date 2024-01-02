using BlibliotecaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlibliotecaApp.Services
{
    internal interface IEditorialService
    {
        Task<List<EditorialModel>> ListaEditoriales();

        Task<EditorialModel> BuscarEditorial(string id);

        Task<bool> GuardarEditorial(EditorialModel editorialModel);

        Task<bool> EditarEditorial(EditorialModel editorialModel);

        Task<bool> EliminarEditorial(string id);
    }
}
