using Employment.Application.Contracts.ApplicationServicesContracts;
using Employment.Application.Contracts.PersistanceContracts;
using Employment.Application.Dtos.ApplicationServicesDtos;
using Employment.Common;
using Employment.Common.Dtos;
using Employment.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Application.Services.ApplicationServices
{
    public class MajorService : IMajorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MajorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<CommandResule<int>> AddAsync(AddMajorDto addMajorDto)
        {
            var isExists = _unitOfWork.MajorRepository.IsExistsWithName(addMajorDto.DisplayName.ToLower());
            if (isExists) throw new DuplicateWaitObjectException(message: ApplicationMessages.DuplicateMajor, parameterName: nameof(AddMajorDto));
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
    }
}
