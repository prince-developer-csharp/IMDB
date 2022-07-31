using IMDBApplication.DTO;
using IMDBApplication.Models;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDBApplication.DataContext.Repository
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        readonly ImdbDbContext _context;
        public MovieRepository(ImdbDbContext imdbDbContext):base(imdbDbContext)
        {
            _context = imdbDbContext;
        }

        public List<MovieDTO> GetMoviesBasedOnActorAndProducer()
        {

            var movieList = (from movie in _context.Movie
                             join producer in _context.Producer
                             on movie.ProducerId equals producer.Id

                             select new MovieDTO
                             {
                                 MovieName = movie.MovieName,
                                 ProducerName = producer.ProducerName,
                                 Actors = (from actorMovie in movie.ActorMovie
                                           join actor in _context.Actor on actorMovie.ActorId equals actor.Id
                                           select actor).ToList()
                             }
                             ).ToList();
            return movieList;
        }
    }
}
