using Employment.Application.Contracts.ApplicationServicesContracts;
using Employment.Application.Contracts.PersistanceContracts;
using Employment.Application.Dtos.ApplicationServicesDtos.MajorDtos;
using Employment.Application.Dtos.ApplicationServicesDtos.MajorDtos.MajorDtoValidators;
using Employment.Application.Dtos.Validations;
using Employment.Common;
using Employment.Common.Contracts;
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
    public class MajorService : IMajorService, IService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MajorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CommandResule<int>> AddAsync(AddMajorDto addMajorDto)
        {
            var validationResult = await new AddMajorDtoValidator(_unitOfWork).ValidateAsync(addMajorDto);
            if (!validationResult.IsValid) throw new InvalidModelException(validationResult.Errors.FirstOrDefault().ErrorMessage);

            var major = new Major()
            {
                DisplayName = addMajorDto.DisplayName,
            };
            await _unitOfWork.MajorRepository.AddAsync(major);
            return new CommandResule<int>()
            {
                IsSuccess = true,
                Message = ApplicationMessages.MajorAdded,
                Data = major.Id
            };
        }

        public IEnumerable<GetMajorsListDto> GetList()
        {
            var majors = _unitOfWork.MajorRepository.GetAllAsQueryable().AsNoTracking();
            return majors.Select(ma => new GetMajorsListDto()
            {
                Id = ma.Id,
                DisplayName = ma.DisplayName
            });
        }
    }
}
