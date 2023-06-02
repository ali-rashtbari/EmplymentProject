﻿using Employment.Application.Contracts.PersistanceContracts;
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

        #endregion


    }
}
