using Employment.Application.Contracts.ApplicationServicesContracts;
using Employment.Application.Contracts.PersistanceContracts;
using Employment.Application.Dtos.ApplicationServicesDtos;
using Employment.Application.Dtos.Validations;
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
    public class IndustryService : IIndustryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public IndustryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CommandResule<int>> AddAsync(AddIndustryDto addIndustryDto)
        {
            var validationResult = await new AddIndustryDtoValidator(_unitOfWork).ValidateAsync(addIndustryDto);
            if (!validationResult.IsValid) throw new InvalidModelException(message: validationResult.Errors.FirstOrDefault().ErrorMessage);

            var industry = new Industry()
            {
                Name = addIndustryDto.Name,
            };
            await _unitOfWork.IndustryRepository.AddAsync(industry);
            return new CommandResule<int>()
            {
                IsSuccess = true,
                Message = ApplicationMessages.IndustryAdded,
                Data = industry.Id
            };
        }
    }
}
