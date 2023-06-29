using AutoMapper;
using Employment.Application.Contracts.ApplicationServicesContracts;
using Employment.Application.Contracts.PersistanceContracts;
using Employment.Application.Dtos.ApplicationServicesDtos.LinkDtos;
using Employment.Application.Dtos.ApplicationServicesDtos.LinkDtos.LinkDtoValidators;
using Employment.Application.Dtos.Validations;
using Employment.Common;
using Employment.Common.Dtos;
using Employment.Common.Exceptions;
using Employment.Domain;
using Microsoft.EntityFrameworkCore;
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
            var validationResult = await new AddLinkDtoValidator(_unitOfWork).ValidateAsync(addLinkDto);
            if (!validationResult.IsValid) throw new InvalidModelException(validationResult.Errors.FirstOrDefault().ErrorMessage);

            var resume = _unitOfWork.ResumeRepository.Get(id: addLinkDto.ResumeId, includes: new List<string>()
            {
                "Links"
            });
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

        public GetLinkDto Get(int id)
        {
            var link = _unitOfWork.LinkRepository.Get(id);
            if (link == null) throw new NotFoundException(msg: ApplicationMessages.LinkNotFound, entity: nameof(Link), id: id.ToString());
            var linkDto = _mapper.Map<GetLinkDto>(link);
            return linkDto;
        }

        public IEnumerable<GetLinksListDto> GetList(int resumeId)
        {
            var links = _unitOfWork.LinkRepository.GetAllAsQueryable();
            var linksListDto = _mapper.Map<IEnumerable<GetLinksListDto>>(links);
            return linksListDto;
        }
    }
}
