using JobsAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobsAPI.Data
{
    public class JobsDbContext: DbContext
    {
        public JobsDbContext(DbContextOptions<JobsDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role_Programmer>()
                .HasOne(r => r.Role)
                .WithMany(rp => rp.Role_Programmers);
        }

        public DbSet<Job> Jobs { get; set; }
        public DbSet<InfoNote> InfoNotes { get; set; }
        public DbSet<ProgrammersNote> ProgrammersNotes { get; set; }
        public DbSet<OperatorsNote> OperatorsNotes { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Role_Programmer> Role_Programmers { get; set; }
    }
}
