using IMDBApplication.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDBApplication.DataContext.Repository
{
    public class ProducerRepository : Repository<Producer>, IProducerRepository
    {
        public ProducerRepository(ImdbDbContext imdbDbContext):base(imdbDbContext)
        {

        }
    }
}
