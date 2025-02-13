using DataBasse.DBConnection.ReadDbContext;
using DataBasse.ModelConfiguration;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBasse.DBConnection.DeleteDbContext
{
    public class ShortUrlDeleteDbContext : DbContext
    {

        public DbSet<UrlInfo> Urls { get; private set; }

        public ShortUrlDeleteDbContext(DbContextOptions<ShortUrlDeleteDbContext> options)
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
