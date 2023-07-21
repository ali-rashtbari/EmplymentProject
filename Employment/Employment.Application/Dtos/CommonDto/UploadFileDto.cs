using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Application.Dtos.CommonDto
{
    public class UploadFileDto
    {
        public string FileName
        {
            get
            {
                var fileName = this.File.FileName.Split('.').First().Trim();
                return fileName;
            }
        }
        public IFormFile File { get; set; }
        public string Extension
        {
            get
            {
                var fileExtension = "." + this.File.FileName.Split('.').Last().Trim().ToLower();
                return fileExtension;
            }
        }
    }
}
