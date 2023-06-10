using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Application.Contracts.PersistanceContracts
{
    public interface IUnitOfWork
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



        #region Repositories

        public IProfileRepository ProfileRepository { get; }
        public IResumeRepository ResumeRepository { get; }
        public ILinkRepository LinkRepository { get; }
        public IEducationHistoryRepository EducationHistoryRepository { get; }
        public IMajorRepository MajorRepository { get; }
        public ICountryRepository CountryRepository { get; }
        public IProvinceRepository ProvinceRepository { get; }
        public IIndustryRepository IndustryRepository { get; }
        public IJobCategoryRepository IJobCategoryRepository { get; }
        public IJobSeniorityLevelRepository JobSeniorityLevelRepository { get; }
        public ICityRepository CityRepository { get; }

        #endregion


    }
}
