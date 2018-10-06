using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DementiaWebsite.Models
{
    public partial class DB_A2B2C0_group6uclhumberContext : DbContext
    {
        public DB_A2B2C0_group6uclhumberContext()
        {
        }

        public DB_A2B2C0_group6uclhumberContext(DbContextOptions<DB_A2B2C0_group6uclhumberContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Game> Game { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Score> Score { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=sql6006.site4now.net;Initial Catalog=DB_A2B2C0_group6uclhumber;Persist Security Info=True;User ID=DB_A2B2C0_group6uclhumber_admin;Password=group6uclhumber");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>(entity =>
            {
                entity.Property(e => e.GameId).HasColumnName("GameID");

                entity.Property(e => e.GameName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasKey(e => e.Username);

                entity.Property(e => e.Username)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ScoreId).HasColumnName("ScoreID");

                entity.Property(e => e.Username)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Score)
                    .WithMany(p => p.Person)
                    .HasForeignKey(d => d.ScoreId)
                    .HasConstraintName("FK__Person__ScoreID__2B3F6F97");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.Person)
                    .HasForeignKey(d => d.Username)
                    .HasConstraintName("FK__Person__Username__2A4B4B5E");
            });

            modelBuilder.Entity<Score>(entity =>
            {
                entity.Property(e => e.ScoreId).HasColumnName("ScoreID");

                entity.Property(e => e.GameId).HasColumnName("GameID");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.Score)
                    .HasForeignKey(d => d.GameId)
                    .HasConstraintName("FK__Score__GameID__276EDEB3");
            });
        }
    }
}
