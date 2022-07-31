using IMDBApplication.DataContext.UnitOfWorks;
using IMDBApplication.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDBApplication.DataContext.Repository
{
    public class ActorMovieRepository : Repository<ActorMovie>, IActorMovieRepository
    {
        public ActorMovieRepository(ImdbDbContext imdbDbContext) : base(imdbDbContext)
        {

        }
    }
}
