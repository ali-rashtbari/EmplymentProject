﻿using Employment.Application.Contracts.PersistanceContracts;
using Employment.Domain;
using Employment.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Persistance.Repositories
{
    public class ProvinceRepository : GenericRepository<Province>, IProvinceRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProvinceRepository(AppDbContext dbContext) : base(dbContext)
        {
            _appDbContext = dbContext;
        }

        public bool IsExists(string name)
        {
            return _appDbContext.Provinces.Any(p => p.Name.Trim().ToLower() == name.Trim().ToLower());
        }
    }
}
