using Employment.Application.Dtos.CommonDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Application.Contracts.InfrastructureContracts
{
    public interface IFileUploader
    {
        Task<string> UploadResumeFileAsync(UploadFileDto uploadFileDto, string mobile);
    }
}
