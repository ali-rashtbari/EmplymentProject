using Employment.Application.Contracts.PersistanceContracts;
using Employment.Domain;
using Employment.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.AspNetCore.Hosting;
using FluentValidation.Validators;

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
            return _dbContext.SaveChangesAsync();
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        #endregion Methods


        #region Repositoreis

        private readonly IProfileRepository _profileRepository;
        public IProfileRepository ProfileRepository => _profileRepository ?? new ProfileRepository(_dbContext);

        private readonly IResumeRepository _resumeRepository;
        public IResumeRepository ResumeRepository => _resumeRepository ?? new ResumeRepository(_dbContext);

        private readonly ILinkRepository _linkRepository;
        public ILinkRepository LinkRepository => _linkRepository ?? new LinkRepository(_dbContext);

        private readonly IEducationHistoryRepository _educationHistoryRepository;
        public IEducationHistoryRepository EducationHistoryRepository => _educationHistoryRepository ?? new EducationHistoryRepository(_dbContext);

        private readonly IMajorRepository _majorRepository;
        public IMajorRepository MajorRepository => _majorRepository ?? new MajorRepository(_dbContext);

        public readonly ICountryRepository _countryRepository;
        public ICountryRepository CountryRepository => _countryRepository ?? new CountryRepository(_dbContext);

        private readonly IProvinceRepository _provinceRepository;
        public IProvinceRepository ProvinceRepository => _provinceRepository ?? new ProvinceRepository(_dbContext);

        private readonly IIndustryRepository _industryRepository;
        public IIndustryRepository IndustryRepository => _industryRepository ?? new IndustryRepository(_dbContext);

        private readonly IJobCategoryRepository _jobCategoryRepository;
        public IJobCategoryRepository IJobCategoryRepository => _jobCategoryRepository ?? new JobCategoryRepository(_dbContext);

        private readonly IJobSeniorityLevelRepository _jobSeniorityLevelRepository;
        public IJobSeniorityLevelRepository JobSeniorityLevelRepository => _jobSeniorityLevelRepository ?? new JobSeniorityLeveRepository(_dbContext);

        private readonly ICityRepository _cityRepository;
        public ICityRepository CityRepository => _cityRepository ?? new CityRepository(_dbContext);

        private readonly IJobExperienceRepository _jobExperienceRepository;
        public IJobExperienceRepository JobExperienceRepository => _jobExperienceRepository ?? new JobExperienceRepository(_dbContext);

        #endregion


    }
}
