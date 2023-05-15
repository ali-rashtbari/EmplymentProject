using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Application.Contracts.PersistanceContracts
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        Task CommitAsync();
        IDbContextTransaction BeginTransaction();
        Task<IDbContextTransaction> BeginTransactionAsync();
        void RollBackTrasaction();
        Task RollBackTransactionAsync();
        bool IsBeganTransaction();
        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}
