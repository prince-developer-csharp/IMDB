using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IMDBApplication.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }
        public string Biograpy { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string ActorName { get; set; }
    }
}
