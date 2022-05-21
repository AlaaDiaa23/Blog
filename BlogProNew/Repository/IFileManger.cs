using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProNew.Repository
{
 public   interface IFileManger
    {
        Task<string> SaveImage(IFormFile image);
    }
}
