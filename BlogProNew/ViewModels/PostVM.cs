using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProNew.ViewModels
{
    public class PostVM
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Body { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Tags { get; set; }
        [Required]
        public string Category { get; set; }
        public IFormFile Images { get; set; } 
        public DateTime DateTime { get; set; } = DateTime.Now;
    }
}
