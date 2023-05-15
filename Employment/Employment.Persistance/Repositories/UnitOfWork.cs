using Employment.Application.Contracts.PersistanceContracts;
using Employment.Domain;
using Employment.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.AspNetCore.Hosting;

namespace Employment.Persistance.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;

        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;

        }




        #region Methods
        public IDbContextTransaction BeginTransaction()
        {
            var transaction = _dbContext.Database.BeginTransaction();
            return transaction;
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            var transaction = await _dbContext.Database.BeginTransactionAsync();
            return transaction;
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
            _dbContext.Database.CommitTransaction();
        }

        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
            await _dbContext.Database.CommitTransactionAsync();
        }

        public bool IsBeganTransaction()
        {
            return _dbContext.Database.CurrentTransaction != null;
        }

        public async Task RollBackTransactionAsync()
        {
            await _dbContext.Database.RollbackTransactionAsync();
        }

        public void RollBackTrasaction()
        {
            _dbContext.Database.RollbackTransaction();
        }

        public Task<int> SaveChangesAsync()
        {

            foreach (var entry in _dbContext.ChangeTracker.Entries<DomainBaseEntity>())
            {
                entry.Entity.DateModified = DateTime.Now;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                }

            }
            return _dbContext.SaveChangesAsync();
        }

        public int SaveChanges()
        {
            foreach (var entry in _dbContext.ChangeTracker.Entries<DomainBaseEntity>())
            {
                entry.Entity.DateModified = DateTime.Now;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                }

            }
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose();
            GC.SuppressFinalize(this);
        }

        #endregion Methods


    }
}
