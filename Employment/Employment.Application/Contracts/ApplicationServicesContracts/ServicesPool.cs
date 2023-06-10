using AutoMapper;
using Employment.Application.Contracts.PersistanceContracts;
using Employment.Application.Services.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Application.Contracts.ApplicationServicesContracts
{
    public class ServicesPool : IServicesPool
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ServicesPool(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        private readonly IProfileService _profileService;
        public IProfileService ProfileService => _profileService ?? new ProfileService(_unitOfWork, _mapper);

        private readonly IResumeService _resumeService;
        public IResumeService ResumeService => _resumeService ?? new ResumeService();

        private readonly ILinkService _linkService;
        public ILinkService LinkService => _linkService ?? new LinkService(_unitOfWork, _mapper);

        private readonly IMajorService _majorService;
        public IMajorService MajorService => _majorService ?? new MajorService(_unitOfWork);

        private readonly IEducationHistoryService _educationHistoryService;
        public IEducationHistoryService EducationHistoryService => _educationHistoryService ?? new EducationHistoryService(_unitOfWork, _mapper);

        private readonly ICountryService _countryService;
        public ICountryService CountryService => _countryService ?? new CountryService(_unitOfWork);

        private readonly IProvinceService _provinceService;
        public IProvinceService ProvinceService => _provinceService ?? new ProvinceService(_unitOfWork);

        private readonly IIndustryService _industryService;
        public IIndustryService IndustryService => _industryService ?? new IndustryService(_unitOfWork);

        public IJobCategoryService _jobCategoryService;
        public IJobCategoryService JobCategoryService => _jobCategoryService ?? new JobCategoryService(_unitOfWork);

        private readonly IJobSeniorityLevelService _jobSentiorityLeveService;
        public IJobSeniorityLevelService JobSeniorityLevelService => _jobSentiorityLeveService ?? new JobSeniorityLevelService(_unitOfWork);

        private readonly ICityService _cityService;
        public ICityService CityService => _cityService ?? new CityService(_unitOfWork);
    }
}
