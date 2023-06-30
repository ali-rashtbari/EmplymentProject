using AutoMapper;
using Employment.Application.Contracts.ApplicationServicesContracts;
using Employment.Application.Contracts.PersistanceContracts;
using Employment.Application.Dtos.ApplicationServicesDtos.IndustryDtos;
using Employment.Application.Dtos.ApplicationServicesDtos.IndustryDtos.IndustryDtoValidators;
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
    public class IndustryService : IIndustryService, IService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public IndustryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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
        public GetIndustryDto Get(int id)
        {
            var industry = _unitOfWork.IndustryRepository.Get(id);
            if (industry == null) throw new NotFoundException(msg: ApplicationMessages.IndustryNotFound,
                                                              entity: nameof(Industry),
                                                              id: id.ToString());
            var industryDto = _mapper.Map<GetIndustryDto>(industry);
            return industryDto;
        }
        public GetListResultDto<GetIndustriesListDto> GetList(GetIndustriesListRequestDto request)
        {
            var industries = _unitOfWork.IndustryRepository.GetAllAsQueryable();

            #region Filters
            if(!string.IsNullOrWhiteSpace(request.Search))
            {
                industries = industries.Where(ind => ind.Name.ToLower().Contains(request.Search.ToLower()));
            }
            #endregion

            #region Ordering
            industries = industries.SystemOrderBy(orderBy: request.OrderBy,
                                                direction: request.OrderDirection);
            #endregion

            #region Paging
            PagedList<Industry> pagedList = PagedList<Industry>.Create(source: industries,
                                                                     pageSize: request.PageSize,
                                                                     pageNumber: request.PageNumber,
                                                                     search: request.Search);
            #endregion

            var values = _mapper.Map<IReadOnlyList<GetIndustriesListDto>>(pagedList);
            var result = new GetListResultDto<GetIndustriesListDto>()
            {
                Values = values,
                MetaValues = pagedList.MetaData
            };
            return result;
        }
        public async Task<CommandResule<int>> UpdateAsync(UpdateIndustryDto request)
        {
            var validationResult = await new UpdateIndustryDtoValidator(_unitOfWork).ValidateAsync(request);
            if (!validationResult.IsValid) throw new InvalidModelException(validationResult.Errors.FirstOrDefault().ErrorMessage);
            var industry = _unitOfWork.IndustryRepository.Get(request.Id);
            _mapper.Map(request, industry);
            await _unitOfWork.IndustryRepository.UpdateAsync(industry);
            return new CommandResule<int>()
            {
                IsSuccess = true,
                Message = ApplicationMessages.IndustryUpdated,
                Data = industry.Id
            };
        }
    }
}
