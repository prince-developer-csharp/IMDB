using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IMDBApplication.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string MovieName { get; set; }
        public string Plot { get; set; }
        [Required]
        public DateTime DateOfRelease { get; set; }
        public byte[] Poster { get; set; }
        [ForeignKey("Producer")]
        [Required]
        public int ProducerId { get; set; }
        public List<ActorMovie> ActorMovie { get; set; }
    }
}
