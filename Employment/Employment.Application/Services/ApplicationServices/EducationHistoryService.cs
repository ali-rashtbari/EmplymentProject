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
    public class EducationHistoryService : IEducationHistoryService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EducationHistoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CommandResule<int>> AddAsync(AddEducationHistoryDto addEducationHistoryDto)
        {
            var resume = _unitOfWork.ResumeRepository.Get(addEducationHistoryDto.ResumeId, includes: new List<string>()
            {
                "EducationHistories"
            });
            if (resume is null) throw new NotFoundException(msg: ApplicationMessages.ResumeNotFound, entity: nameof(Resume), id: addEducationHistoryDto.ResumeId.ToString());
            var major = _unitOfWork.MajorRepository.Get(addEducationHistoryDto.MajorId);
            if (resume is null) throw new NotFoundException(msg: ApplicationMessages.MajorNotFound, entity: nameof(Major), id: addEducationHistoryDto.MajorId.ToString());
            var educationHistory = _mapper.Map<EducationHistory>(addEducationHistoryDto);
            await _unitOfWork.EducationHistoryRepository.AddAsync(educationHistory);
            return new CommandResule<int>()
            {
                IsSuccess = true,
                Message = ApplicationMessages.EducationHistoryAdded,
                Data = educationHistory.Id
            };
        }
    }
}
