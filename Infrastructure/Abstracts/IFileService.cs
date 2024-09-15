using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Abstracts
{
    public interface IFileService
    {
        Task<string> UploadAsync(IFormFile file);
        Task<string> ChangeFileAsync(string oldFilePath, IFormFile file);
    }
}
