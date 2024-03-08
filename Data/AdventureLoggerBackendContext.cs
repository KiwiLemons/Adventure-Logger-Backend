using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AdventureLoggerBackend.Models;

namespace AdventureLoggerBackend.Data
{
    public class AdventureLoggerBackendContext : DbContext
    {
        public AdventureLoggerBackendContext (DbContextOptions<AdventureLoggerBackendContext> options)
            : base(options)
        {
        }

        public DbSet<AdventureLoggerBackend.Models.User> User { get; set; } = default!;
        public DbSet<AdventureLoggerBackend.Models.Route> Route { get; set; } = default!;
        public DbSet<AdventureLoggerBackend.Models.Friend> Friend { get; set; } = default!;


    }
}
