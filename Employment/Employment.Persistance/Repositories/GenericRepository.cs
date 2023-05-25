using Employment.Application.Contracts.PersistanceContracts;
using Employment.Persistance.Context;
using Microsoft.AspNetCore.Routing.Template;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Persistance.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        private readonly AppDbContext _dbContext;

        public GenericRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
        }

        public async Task AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _dbContext.Set<T>().Find(id);
            _dbContext.Entry<T>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _dbContext.SaveChanges();
        }

        public T Get(int id, List<string> includes = null)
        {
            var entity = _dbContext.Set<T>().Find(id);
            return GetAsQueryable(includes).FirstOrDefault();
        }

        public IEnumerable<T> GetAll(List<string> includes = null)
        {
            var entiteis = _dbContext.Set<T>().AsEnumerable();
            return GetAsQueryable(includes).AsEnumerable();
        }

        public async Task<T> GetAsync(int id, List<string> includes = null)
        {
            var entity = await _dbContext.Set<T>().FindAsync(id);

            return await GetAsQueryable(includes).FirstOrDefaultAsync();
        }

        public void Update(T entity)
        {
            _dbContext.Entry<T>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry<T>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }


        private IQueryable<T> GetAsQueryable(List<string> includes = null)
        {
            var entity = _dbContext.Set<T>().AsQueryable();
            if(includes.Any())
            {
                foreach (var include in includes)
                {
                    entity.Include(include);
                }
            }
            return entity;
        }
    }
}
