using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using DataBasse.ModelConfiguration;

namespace DataBasse.DBConnection.ReadDbContext
{
    public class ShortUrlReadDbContext : DbContext
    {
        public DbSet<UrlInfo> Urls { get; private set; }

        public ShortUrlReadDbContext(DbContextOptions<ShortUrlReadDbContext> options) 
            : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ShortUrlReadModel());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

    }
}
