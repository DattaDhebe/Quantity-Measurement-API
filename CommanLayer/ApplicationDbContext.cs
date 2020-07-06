using CommanLayer.Model;
using Microsoft.EntityFrameworkCore;

namespace RepositoryLayer
{
    public class ApplicationDbContext : DbContext
    {
        // Parameterized Constructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { 
        }

        //Dbset for Quantity table
        public DbSet<Quantity> Quantities { get; set; }

    }
}

