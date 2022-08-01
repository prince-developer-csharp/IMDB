using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IMDBApplication.Models
{
    public class ActorMovie
    {
        [Key]
        public int Id { get; set; }
        public int ActorId { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public Actor Actor { get; set; }

    }
}
