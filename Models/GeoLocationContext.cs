using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Geomap.Models
{
    public partial class GeoLocationContext : DbContext
    {
        public GeoLocationContext()
        {
        }

        public GeoLocationContext(DbContextOptions<GeoLocationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<GeoTable1> GeoTable1s { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Use Your SQL Connection String");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Turkish_CI_AS");

            modelBuilder.Entity<GeoTable1>(entity =>
            {
                entity.HasKey(e => e.Geoid);

                entity.ToTable("GeoTable1");

                entity.Property(e => e.Ber).HasColumnName("ber");

                entity.Property(e => e.Cur)
                    .HasMaxLength(10)
                    .HasColumnName("cur")
                    .IsFixedLength(true);

                entity.Property(e => e.Geometry)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("geometry");

                entity.Property(e => e.Id)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("id");

                entity.Property(e => e.Kmetin)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("kmetin");

                entity.Property(e => e.Lat)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("lat");

                entity.Property(e => e.Long)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("long");

                entity.Property(e => e.Ometin)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("ometin");

                entity.Property(e => e.Paftaadi)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("paftaadi");

                entity.Property(e => e.Propid).HasColumnName("propid");

                entity.Property(e => e.Sp)
                    .HasMaxLength(10)
                    .HasColumnName("sp")
                    .IsFixedLength(true);

                entity.Property(e => e.Umetin)
                    .HasMaxLength(350)
                    .IsUnicode(false)
                    .HasColumnName("umetin");

                entity.Property(e => e.Zo).HasColumnName("zo");
            });

            OnModelCreatingPartial(modelBuilder);

       
    }

        //entities
        public DbSet<GeoTable1> GeoInfo { get; set; }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
