using API_Libros_BL.Data;
using API_Libros_BL.Models;
using System.Data.Entity;
using System.Threading.Tasks;

namespace API_Libros_BL.Repositories.Implements
{
    public class AutorRepository : GenericRepository<Autor>, IAutorRepository
    {
        private readonly LibrosContext librosContext;
        //solo recibe el parametro y lo manda a la herencia
        public AutorRepository(LibrosContext librosContext) : base(librosContext) 
        {
            this.librosContext = librosContext;
        }

        public async Task<bool> DeleteCheckOnEntity(string id)
        {
            var flag = await librosContext.Autores.AnyAsync(x => x.id_autor.Equals(id));
            return flag;            
        }
    }
}
