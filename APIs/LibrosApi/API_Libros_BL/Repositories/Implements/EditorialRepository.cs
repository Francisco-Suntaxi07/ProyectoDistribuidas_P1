using API_Libros_BL.Data;
using API_Libros_BL.Models;
using System.Data.Entity;
using System.Threading.Tasks;

namespace API_Libros_BL.Repositories.Implements
{
    public class EditorialRepository : GenericRepository<Editorial>, IEditorialRepository
    {
        private readonly LibrosContext librosContext;
        public EditorialRepository(LibrosContext librosContext)  : base(librosContext)
        {
            this.librosContext = librosContext;
        }

        public async Task<bool> DeleteCheckOnEntity(string id)
        {
            var flag = await librosContext.Editoriales.AnyAsync(x => x.id_editorial.Equals(id));
            return flag;
        }
    }
}
