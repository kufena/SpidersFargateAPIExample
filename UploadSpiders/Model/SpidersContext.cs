using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace UploadSpiders.Model
{
    public partial class SpidersContext : DbContext
    {
        private string connect;

        public SpidersContext(string connect) : base()
        {
            this.connect = connect;
        }

        public SpidersContext(DbContextOptions<SpidersContext> options)
            : base(options)
        {
            connect = "";
        }

        public virtual DbSet<Family> Families { get; set; } = null!;
        public virtual DbSet<Species> Species { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(connect, Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.30-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Family>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(256);

                entity.Property(e => e.Name).HasMaxLength(1024);
            });

            modelBuilder.Entity<Species>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(256);

                entity.Property(e => e.Family).HasMaxLength(256);

                entity.Property(e => e.GenusName).HasMaxLength(1024);

                entity.Property(e => e.SpeciesName).HasMaxLength(1024);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
