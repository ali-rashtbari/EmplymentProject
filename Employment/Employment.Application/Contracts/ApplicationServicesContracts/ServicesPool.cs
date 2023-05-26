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
    }
}
