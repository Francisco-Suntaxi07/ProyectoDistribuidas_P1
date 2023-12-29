using API_Libros_BL.Models;
using API_Libros_BL.Repositories;
using System.Threading.Tasks;

namespace API_Libros_BL.Services.Implements
{
    public class AutorService : GenericService<Autor>, IAutorService
    {
        private readonly IAutorRepository autorRepository;
        public AutorService(IAutorRepository autorRepository) : base(autorRepository)
        {
            this.autorRepository = autorRepository;
        }

        public async Task<bool> DeleteCheckOnEntity(string id)
        {
            return await autorRepository.DeleteCheckOnEntity(id);
        }
    }
}