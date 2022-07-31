using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDBApplication.DataContext.Repository
{
    public class Repository<entity> : IRepository<entity> where entity : class
    {
        private readonly ImdbDbContext _imdbDbContext;
        public Repository(ImdbDbContext imdbDbContext)
        {
            _imdbDbContext = imdbDbContext;
        }

        public async Task<entity> Add(entity entity)
        {
            await _imdbDbContext.Set<entity>().AddAsync(entity);
            return entity;
        }

        public void AddRange(IEnumerable<entity> entities)
        {
            _imdbDbContext.Set<entity>().AddRange(entities);
        }

        public async Task<IEnumerable<entity>> GetAll()
        {
            return await _imdbDbContext.Set<entity>().ToListAsync();
        }

        public async Task<entity> GetById(int id)
        {
            return await _imdbDbContext.Set<entity>().FindAsync(id);
        }

        public  void Remove(entity entity)
        {
            _imdbDbContext.Set<entity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<entity> entities)
        {
            _imdbDbContext.Set<entity>().RemoveRange(entities);
        }

        public  entity Update(entity entity)
        {
             _imdbDbContext.Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }
}
