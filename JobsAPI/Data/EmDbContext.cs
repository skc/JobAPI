using JobsAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobsAPI.Data
{
    public class EmDbContext : DbContext
    {
        public EmDbContext(DbContextOptions<EmDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobDef>().HasNoKey();
        }

        public DbSet<JobDef> JobDefs { get; set; }
    }
}
