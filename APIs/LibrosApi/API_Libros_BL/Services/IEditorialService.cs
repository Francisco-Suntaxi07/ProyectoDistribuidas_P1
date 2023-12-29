using API_Libros_BL.Models;
using System.Threading.Tasks;

namespace API_Libros_BL.Services
{
    public interface IEditorialService : IGenericService<Editorial>
    {
        Task<bool> DeleteCheckOnEntity(string id);
    }
}
