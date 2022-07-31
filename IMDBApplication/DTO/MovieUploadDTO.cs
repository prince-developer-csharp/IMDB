using IMDBApplication.Models;

using Microsoft.AspNetCore.Http;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IMDBApplication.DTO
{
    public class MovieUploadDTO
    {
        public int Id { get; set; }
        public IFormFile file { get; set; }
        public string MovieName { get; set; }
        public string Plot { get; set; }
        [Required]
        public DateTime DateOfRelease { get; set; }
        [ForeignKey("Producer")]
        [Required]
        public int ProducerId { get; set; }
        [Required]
        public string ActorMovie { get; set; }
    }
}
