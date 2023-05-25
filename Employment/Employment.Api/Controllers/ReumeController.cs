using AutoMapper;
using Employment.Application.Contracts.PersistanceContracts;
using Employment.Application.Dtos.ApplicationServicesDtos;
using Employment.Application.Dtos.Validations;
using Employment.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employment.Api.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class ReumeController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReumeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost("AddLink")]
        public async Task<IActionResult> AddLink([FromBody] AddLinkDto addLinkDto)
        {
            var validationResult = await new AddLinkDtoValidator().ValidateAsync(addLinkDto);
            if(!validationResult.IsValid)
            {
                throw new InvalidModelException(validationResult.Errors.FirstOrDefault().ErrorMessage);
            }

            var prof = _unitOfWork.ProfileRepository.Get(addLinkDto.ResumeId);

            if(prof is null)
            {
                throw new NotFoundException("prof not found.", nameof(Profile), addLinkDto.ResumeId.ToString());
            }

            return Ok();

        }

    }
}
