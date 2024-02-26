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

        // Method to print database contents (for debugging or testing purposes)
        public void PrintDatabaseContents()
        {
            // Retrieve all users from the database
            var users = this.User.ToList();
            Console.WriteLine("Hey hey hey, you arent in the users yet!");
            // Print user information
            foreach (var user in users)
            {
                Console.WriteLine("Hey hey hey! Right below me is the tagline for the database");
                Console.WriteLine($"ID: {user.user_id}, Username: {user.UserName}, Password: {user.Password}");
            }
        }


    }
}
