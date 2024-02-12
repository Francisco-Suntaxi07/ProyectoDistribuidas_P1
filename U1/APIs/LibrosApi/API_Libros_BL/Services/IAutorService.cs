using API_Libros_BL.Models;
using System.Threading.Tasks;

namespace API_Libros_BL.Services
{
    public interface IAutorService : IGenericService<Autor>
    {
        Task<bool> DeleteCheckOnEntity(string id);
    }
}
