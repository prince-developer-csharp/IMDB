using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDBApplication.DataContext
{
    public interface IUnitOfWork : IDisposable
    {
        IProducerRepository ProducerRepository { get; }
        IActorRepository ActorRepository { get; }
        IMovieRepository MovieRepository { get; }
        IActorMovieRepository ActorMovieRepository { get; }
        int Complete();
    }
}
