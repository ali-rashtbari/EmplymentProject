using Employment.Application.Contracts.InfrastructureContracts;
using Employment.Application.Dtos.CommonDto;
using Employment.Application.Dtos.CommonDto.CommonDtoValidators;
using Employment.Common;
using Employment.Common.Exceptions;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Infrastructure.Services
{
    public class FileUploader : IFileUploader
    {
        private readonly IWebHostEnvironment _env;
        public FileUploader(IWebHostEnvironment webHostEnvironment)
        {
            _env = webHostEnvironment;
        }

        public async Task<string> UploadResumeFileAsync(UploadFileDto uploadFileDto, string mobile)
        {
            var validationResult = await new UploadFileDtoValidator().ValidateAsync(uploadFileDto);
            if (!validationResult.IsValid)
            {
                throw new InvalidModelException(validationResult.Errors.FirstOrDefault().ErrorMessage);
            }
            if (uploadFileDto.Extension != ".pdf")
            {
                throw new Exception("only '.pdf' files can be uploaded.");
            }

            // base path ---
            var resumesFolderPath = Path.Combine("wwwroot", "Resumes");
            string baseSavePath = Path.Combine(Directory.GetCurrentDirectory(), resumesFolderPath);
            if (!Directory.Exists(baseSavePath))
            {
                Directory.CreateDirectory(baseSavePath);
            }

            var userFolderPath = Path.Combine(baseSavePath, $"User-{mobile}");
            if (!Directory.Exists(userFolderPath))
            {
                Directory.CreateDirectory(userFolderPath);
            }
            
            // file name ---
            var fileName = uploadFileDto.FileName + "-" + DateTime.Now.Ticks.ToString() + uploadFileDto.Extension;
            var pathWithFileName = Path.Combine(userFolderPath, fileName + uploadFileDto.Extension);

            // save ---
            using var stream = new FileStream(pathWithFileName, FileMode.Create);
            await uploadFileDto.File.CopyToAsync(stream);

            return pathWithFileName;
        }
    }
}
