using Employment.Application.Contracts.InfrastructureContracts;
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
        public IProvinceService ProvinceService { get; }
        public IIndustryService IndustryService { get; }
        public IJobCategoryService JobCategoryService { get; }
        public IJobSeniorityLevelService JobSeniorityLevelService { get; }
        public ICityService CityService { get; }
        public IJobExperienceService JobExperienceService { get; }
        public ILanguageService LanguageService { get; }
        public ICategoryService CategoryService { get; }
        public ICommonService CommonService { get; }
    }
}
