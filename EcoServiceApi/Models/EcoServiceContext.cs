using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoServiceApi.Models
{
    public class EcoServiceContext : DbContext
    {
        public EcoServiceContext(DbContextOptions<EcoServiceContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<UserNewsDetail>()
            //    .HasOne<UserDetail>(u => u.UserDetail)
            //   .WithMany(s => s.UserNewsDetails)
        }

        public DbSet<UserDetail> UserDetails { get; set; }
        public DbSet<PollutionDetail> PollutionDetails { get; set; }
        public DbSet<EventDetail> EventDetails { get; set; }
        public DbSet<NewsDetail> NewsDetails { get; set; }
    }
}
