using API_Libros_BL.Models;
using API_Libros_BL.Repositories;
using API_Libros_BL.Repositories.Implements;
using System.Threading.Tasks;

namespace API_Libros_BL.Services.Implements
{
    public class GeneroService : GenericService<Genero>, IGeneroService
    {
        private readonly IGeneroRepository generoRepository;
        public GeneroService(IGeneroRepository generoRepository) : base(generoRepository) 
        {
            this.generoRepository = generoRepository;
        }

        public async Task<bool> DeleteCheckOnEntity(string id)
        {
            return await generoRepository.DeleteCheckOnEntity(id);
        }
    }
}
