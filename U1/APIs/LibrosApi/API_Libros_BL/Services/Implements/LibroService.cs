using API_Libros_BL.Data;
using API_Libros_BL.Models;
using API_Libros_BL.Repositories;
using API_Libros_BL.Repositories.Implements;
using System.Collections;
using System.Threading.Tasks;

namespace API_Libros_BL.Services.Implements
{
    public class LibroService : GenericService<Libro>, ILibroService
    {
        private readonly ILibroRepository libroRepository;

        public LibroService(ILibroRepository libroRepository) : base(libroRepository)
        {
            this.libroRepository = libroRepository;
        }
        public async Task<bool> DeleteCheckOnEntity(string id)
        {
            return await libroRepository.DeleteCheckOnEntity(id);
        }
    }
}
