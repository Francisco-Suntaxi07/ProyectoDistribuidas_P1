using API_Libros_BL.Data;
using API_Libros_BL.Models;
using System.Data.Entity;
using System.Threading.Tasks;

namespace API_Libros_BL.Repositories.Implements
{
    public class LibroRepository : GenericRepository<Libro>, ILibroRepository
    {
        private readonly LibrosContext librosContext;
        public LibroRepository(LibrosContext librosContext) : base(librosContext)
        {
            this.librosContext = librosContext;
        }

        public async Task<bool> DeleteCheckOnEntity(string id)
        {
            var flag = await librosContext.Libros.AnyAsync(x => x.id_libro.Equals(id));
            return flag;
        }
    }
}
