using AutoMapper;
using Employment.Application.Contracts.ApplicationServicesContracts;
using Employment.Application.Contracts.PersistanceContracts;
using Employment.Application.Dtos.ApplicationServicesDtos;
using Employment.Common;
using Employment.Common.Dtos;
using Employment.Common.Exceptions;
using Employment.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Application.Services.ApplicationServices
{
    public class LinkService : ILinkService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LinkService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<CommandResule<int>> AddAsync(AddLinkDto addLinkDto)
        {
            var resume = _unitOfWork.ResumeRepository.Get(id: addLinkDto.ResumeId, includes: new List<string>()
            {
                "Links"
            });
            if (resume.Links.Count() >= 5) throw new Exception(ApplicationMessages.CantAddMoreLinks);
            if (resume is null) throw new NotFoundException(msg: ApplicationMessages.ResumeNotFound, 
                                                            entity: nameof(resume), 
                                                            id: addLinkDto.ResumeId.ToString());
            var link = _mapper.Map<Link>(addLinkDto);
            await _unitOfWork.LinkRepository.AddAsync(link);
            await _unitOfWork.LinkRepository.AddToResumeAsync(link.Id, resume.Id);
            return new CommandResule<int>()
            {
                IsSuccess = true,
                Message = ApplicationMessages.LinkAddedToResume,
                Data = link.Id
            };
        }
    }
}
