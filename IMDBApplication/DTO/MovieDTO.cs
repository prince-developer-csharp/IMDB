using IMDBApplication.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace IMDBApplication.DTO
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string MovieName { get; set; }
        public List<Actor> Actors { get; set; }
        public string ProducerName { get; set; }

    }
}
