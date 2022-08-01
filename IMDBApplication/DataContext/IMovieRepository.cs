using IMDBApplication.DTO;
using IMDBApplication.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDBApplication.DataContext
{
    public interface IMovieRepository : IRepository<Movie>
    {
        List<MovieDTO> GetMoviesBasedOnActorAndProducer();
    }
}
