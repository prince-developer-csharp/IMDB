using IMDBApplication.Models;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDBApplication.DataContext
{
    public class ImdbDbContext:DbContext
    {
        public ImdbDbContext(DbContextOptions<ImdbDbContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movie { get; set; }
        public DbSet<Actor> Actor { get; set; }
        public DbSet<Producer> Producer { get; set; }
        public DbSet<ActorMovie> ActorMovie { get; set; }
    }
}
