using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProNew.Repository
{
    public class FileManger : IFileManger
    {
        private string _imagePath;

        public FileManger(IConfiguration configuration)
        {
            _imagePath = configuration[ "Path:Images"];
        }
        public async Task<string> SaveImage(IFormFile image)
        {
            var save_path = Path.Combine(_imagePath);
            if (!Directory.Exists(save_path))
            {
                Directory.CreateDirectory(save_path);

            }
            var mime = image.FileName.Substring(image.FileName.LastIndexOf('.'));
            var fileName = $"_img{DateTime.Now.ToString("dd,mm,yyyy,hh,mm,ss")}{mime}";
            using (var filestream = new FileStream(Path.Combine(save_path, fileName), FileMode.Create))
            {
             await  image.CopyToAsync(filestream);
            }
            return fileName;
        }
    }
}
