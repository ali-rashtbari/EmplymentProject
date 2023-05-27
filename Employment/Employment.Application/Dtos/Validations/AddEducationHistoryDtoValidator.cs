using Employment.Application.Dtos.ApplicationServicesDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Application.Dtos.Validations
{
    public class AddEducationHistoryDtoValidator : AbstractValidator<AddEducationHistoryDto>
    {
        public AddEducationHistoryDtoValidator()
        {
            
        }
    }
}
