using API_Libros_BL.Models;
using System.Threading.Tasks;

namespace API_Libros_BL.Repositories
{
    public interface IAutorRepository : IGenericRepository<Autor>
    {
        Task<bool> DeleteCheckOnEntity(string id);
    }
}