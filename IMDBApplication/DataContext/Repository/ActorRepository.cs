using IMDBApplication.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDBApplication.DataContext.Repository
{
    public class ActorRepository : Repository<Actor>, IActorRepository
    {
        public ActorRepository(ImdbDbContext imdbDbContext):base(imdbDbContext)
        {

        }
    }
}
