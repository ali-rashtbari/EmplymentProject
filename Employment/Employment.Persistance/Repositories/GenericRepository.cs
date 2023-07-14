using Employment.Application.Contracts.PersistanceContracts;
using Employment.Common;
using Employment.Persistance.Context;
using Microsoft.AspNetCore.Routing.Template;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public T Get(int id, List<string>? includes = null)
        {
            var expression = CommonTools.GetLambdaExpression<T, int>("Id", id);
            return GetAsQueryable(expression, includes: includes).FirstOrDefault();
        }

        public IEnumerable<T> GetAll(List<string>? includes = null)
        {
            return GetAsQueryable(expression: null, includes: includes).AsEnumerable();
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

        public IQueryable<T> GetAllAsQueryable(List<string>? includes)
        {
            return GetAsQueryable(expression: null, includes: includes);
        }

        private IQueryable<T> GetAsQueryable(Expression<Func<T, bool>>? expression = null, List<string>? includes = null)
        {
            IQueryable<T> entities = null;
            if(includes != null && includes.Count() > 0)
            {
                entities = _dbContext.Set<T>().AsNoTrackingWithIdentityResolution().AsQueryable();
            }
            else
            {
                entities = _dbContext.Set<T>().AsNoTracking().AsQueryable();
            }
            if(expression is not null)
            {
                entities = entities.Where(expression);
            }
            if(includes != null && includes.Any())
            {
                foreach (var include in includes)
                {
                    entities = entities.Include(include);
                }
            }
            return entities;
        }
    }
}
