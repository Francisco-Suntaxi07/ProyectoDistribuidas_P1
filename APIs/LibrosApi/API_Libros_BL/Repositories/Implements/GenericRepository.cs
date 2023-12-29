using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Threading.Tasks;
using API_Libros_BL.Data;

namespace API_Libros_BL.Repositories.Implements
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly LibrosContext librosContext;

        public GenericRepository(LibrosContext librosContext)
        {
            this.librosContext = librosContext;
        }

        public async Task Delete(string id)
        {
            var entity = await GetById(id);

            if (entity == null)
                throw new Exception("La entidad es null");

            librosContext.Set<TEntity>().Remove(entity);
            await librosContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await librosContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById(string id)
        {
            return await librosContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            librosContext.Set<TEntity>().Add(entity);
            await librosContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            //librosContext.Entry(entity).State = EntityState.Modified;
            librosContext.Set<TEntity>().AddOrUpdate(entity); //OTRO METODO
            await librosContext.SaveChangesAsync();
            return entity;
        }
    }
}