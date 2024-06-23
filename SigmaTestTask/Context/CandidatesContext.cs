using Microsoft.EntityFrameworkCore;
using SigmaTestTask.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace SigmaTestTask.Context
{
    public class CandidatesContext : DbContext
    {
        public CandidatesContext(DbContextOptions<CandidatesContext> options)
           : base(options)
        {
        }

        public DbSet<Candidate> Candidates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Candidate>()
                .HasIndex(c => c.Email)
                .IsUnique();
        }
    }
}
