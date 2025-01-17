using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ECFJanvier.Models;

namespace ECFJanvier.Data
{
    public class ECFJanvierContext : DbContext
    {
        public ECFJanvierContext (DbContextOptions<ECFJanvierContext> options)
            : base(options)
        {
        }

        public DbSet<ECFJanvier.Models.Evenement> Evenement { get; set; } = default!;
        public DbSet<ECFJanvier.Models.Participant> Participant { get; set; } = default!;

        public DbSet<EvenementParticipant> EvenementParticipant { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EvenementParticipant>()
                .HasKey(pe => new { pe.ParticipantId, pe.EvenementId });

            modelBuilder.Entity<EvenementParticipant>()
                .HasOne(pe => pe.Participant)
                .WithMany(p => p.Evenements)
                .HasForeignKey(pe => pe.ParticipantId);

            modelBuilder.Entity<EvenementParticipant>()
                .HasOne(pe => pe.Evenement)
                .WithMany(e => e.Participants)
                .HasForeignKey(pe => pe.EvenementId);
        }
    }
}
