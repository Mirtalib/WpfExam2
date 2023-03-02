using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Source.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Context
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var configurationRoot = new ConfigurationManager()
            //    .AddJsonFile("appsettings.json", true, true)
            //    .Build();

            //var connectionString = configurationRoot.GetConnectionString("conStr");
            //if (connectionString == null)
            //    return;
            //    //throw (new FileNotFoundException());

            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=NetflixDB;Integrated Security=True;");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Movie>? Movies { get; set; }
        public DbSet<Rating>? Ratings { get; set; }
        public DbSet<User>? Users { get; set; }

    }
}
