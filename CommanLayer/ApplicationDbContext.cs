﻿using CommanLayer;
using CommanLayer.Models;
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

        //Dbset for Quantity table
        public DbSet<Quantity> Quantities { get; set; }

        public DbSet<Compare> Comparision { get; set; }

    }
}

