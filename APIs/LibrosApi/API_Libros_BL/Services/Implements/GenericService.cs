using System.Collections.Generic;
using System.Threading.Tasks;
using API_Libros_BL.Repositories;

namespace API_Libros_BL.Services.Implements
{
    public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : class
    {
        private IGenericRepository<TEntity> genericRepository;//unicamente llama al repositorio

        public GenericService(IGenericRepository<TEntity> genericRepository)
        {
            this.genericRepository = genericRepository;
        }

        public async Task Delete(string id)
        {
            await genericRepository.Delete(id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await genericRepository.GetAll();
        }

        public async Task<TEntity> GetById(string id)
        {
            return await genericRepository.GetById(id);
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            return await genericRepository.Insert(entity);
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            return await genericRepository.Update(entity);
        }
    }
}
