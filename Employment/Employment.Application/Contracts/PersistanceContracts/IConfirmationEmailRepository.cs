﻿using Employment.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Application.Contracts.PersistanceContracts
{
    public interface IConfirmationEmailRepository : IGenericRepository<ConfirmationEmail>
    {
        Task<ConfirmationEmail> GetUserLastActiveConfirmationEmail(string userId);
        Task<ConfirmationEmail> GetUserLastConfirmationEmail(string userId);
    }
}
