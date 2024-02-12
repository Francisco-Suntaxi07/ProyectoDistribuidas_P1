using API_Libros_BL.Models;
using API_Libros_BL.Repositories;
using API_Libros_BL.Repositories.Implements;
using System.Threading.Tasks;

namespace API_Libros_BL.Services.Implements
{
    public class EditorialService : GenericService<Editorial>, IEditorialService
    {
        private readonly IEditorialRepository editorialRepository;

        public EditorialService(IEditorialRepository editorialRepository) : base(editorialRepository)
        {
            this.editorialRepository = editorialRepository;
        }

        public async Task<bool> DeleteCheckOnEntity(string id)
        {
            return await editorialRepository.DeleteCheckOnEntity(id);
        }
    }
}
