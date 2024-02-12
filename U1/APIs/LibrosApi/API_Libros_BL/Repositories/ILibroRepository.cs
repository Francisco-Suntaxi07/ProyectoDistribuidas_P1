using API_Libros_BL.Models;
using System.Threading.Tasks;

namespace API_Libros_BL.Repositories
{
    public interface ILibroRepository : IGenericRepository<Libro>
    {
        Task<bool> DeleteCheckOnEntity(string id);
    }
}
