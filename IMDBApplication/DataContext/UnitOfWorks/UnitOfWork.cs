using IMDBApplication.DataContext.Repository;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDBApplication.DataContext.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ImdbDbContext _imdbDbContext;

        public UnitOfWork(ImdbDbContext imdbDbContext)
        {
            _imdbDbContext = imdbDbContext;
            ProducerRepository = new ProducerRepository(_imdbDbContext);
            ActorRepository = new ActorRepository(_imdbDbContext);
            MovieRepository = new MovieRepository(_imdbDbContext);
            ActorMovieRepository = new ActorMovieRepository(_imdbDbContext);
        }
        public IProducerRepository ProducerRepository { get; private set; }

        public IActorRepository ActorRepository { get; private set; }

        public IMovieRepository MovieRepository  { get; private set; }

        public IActorMovieRepository ActorMovieRepository { get; private set; }
        public int Complete()
        {
            return _imdbDbContext.SaveChanges();
        }

        public void Dispose()
        {
            _imdbDbContext.Dispose();
        }
    }
}
