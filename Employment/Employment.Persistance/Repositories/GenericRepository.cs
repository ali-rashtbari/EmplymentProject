using Employment.Application.Contracts.PersistanceContracts;
using Employment.Persistance.Context;
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

        public T Get(int id)
        {
            var entity = _dbContext.Set<T>().Find(id);
            return entity;
        }

        public IEnumerable<T> GetAll()
        {
            var entiteis = _dbContext.Set<T>().AsEnumerable();
            return entiteis;
        }

        public async Task<T> GetAsync(int id)
        {
            var entity = await _dbContext.Set<T>().FindAsync(id);
            return entity;
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
    }
}
