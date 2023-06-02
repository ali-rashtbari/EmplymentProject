using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Application.Contracts.ApplicationServicesContracts
{
    public interface IServicesPool
    {
        public IProfileService ProfileService { get; }
        public IResumeService ResumeService { get; }
        public ILinkService LinkService { get; }
        public IMajorService MajorService { get; }
        public IEducationHistoryService EducationHistoryService { get; }
        public ICountryService CountryService { get; }
    }
}
