using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Application.Contracts.PersistanceContracts
{
    public interface IGenericRepository<T> where T : class
    {


        // get ---
        IEnumerable<T> GetAll();
        T Get(int id);
        Task<T> GetAsync(int id);

        // update ---
        Task UpdateAsync(T entity);
        void Update(T entity);

        // delete ---
        void Delete(T entity);
        void Delete(int id);

        // add ---
        Task AddAsync(T entity);
        void Add(T entity);
    }
}
