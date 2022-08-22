using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace UploadSpiders.TaxonomyModel
{
    public partial class Spiders2Context : DbContext
    {
        public Spiders2Context()
        {
        }

        public Spiders2Context(DbContextOptions<Spiders2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Family> Families { get; set; } = null!;
        public virtual DbSet<Genu> Genus { get; set; } = null!;
        public virtual DbSet<Species> Species { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.30-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Family>(entity =>
            {
                entity.ToTable("Family");

                entity.Property(e => e.Id).HasMaxLength(256);

                entity.Property(e => e.FamilyName).HasMaxLength(256);
            });

            modelBuilder.Entity<Genu>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(256);

                entity.Property(e => e.FamilyId).HasMaxLength(256);

                entity.Property(e => e.GenusName).HasMaxLength(256);
            });

            modelBuilder.Entity<Species>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(256);

                entity.Property(e => e.GenusId).HasMaxLength(256);

                entity.Property(e => e.SpeciesName).HasMaxLength(256);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
