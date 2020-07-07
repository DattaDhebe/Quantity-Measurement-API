using CommanLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace RepositoryLayer
{
    public class ApplicationDbContext : DbContext
    {
        // Parameterized Constructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { 
        }

        //IDesignTimeDbContextFactory<ApplicationDbContext> designTimeDbContextFactory
        //Dbset for Quantity table
        public DbSet<Quantity> Quantities { get; set; }

    }
}

