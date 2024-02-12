using API_Libros_BL.Models;
using System.Threading.Tasks;

namespace API_Libros_BL.Repositories
{
    public interface IGeneroRepository : IGenericRepository<Genero>
    {
        Task<bool> DeleteCheckOnEntity(string id);
    }
}
