using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace calculate.Models
{
    public partial class calculatorContext : DbContext
    {
        public calculatorContext()
        {
        }

        public calculatorContext(DbContextOptions<calculatorContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<Fershet> Fershet { get; set; }
        public virtual DbSet<Holiday> Holiday { get; set; }
        public virtual DbSet<Holidayfursh> Holidayfursh { get; set; }
        public virtual DbSet<Holidayservices> Holidayservices { get; set; }
        public virtual DbSet<Klient> Klient { get; set; }
        public virtual DbSet<Room> Room { get; set; }
        public virtual DbSet<Services> Services { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=LIDIA28;database=calculator");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("event");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nameevent)
                    .IsRequired()
                    .HasColumnName("nameevent")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Fershet>(entity =>
            {
                entity.ToTable("fershet");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cost).HasColumnName("cost");

                entity.Property(e => e.Descriptions)
                    .IsRequired()
                    .HasColumnName("descriptions")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Namefershet)
                    .IsRequired()
                    .HasColumnName("namefershet")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.People)
                    .IsRequired()
                    .HasColumnName("people")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Holiday>(entity =>
            {
                entity.ToTable("holiday");

                entity.HasIndex(e => e.Eventid)
                    .HasName("eventid");

                entity.HasIndex(e => e.Klientid)
                    .HasName("klientid");

                entity.HasIndex(e => e.Roomid)
                    .HasName("roomid");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Enddate)
                    .HasColumnName("enddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Eventid).HasColumnName("eventid");

                entity.Property(e => e.Hours).HasColumnName("hours");

                entity.Property(e => e.Klientid).HasColumnName("klientid");

                entity.Property(e => e.Roomid).HasColumnName("roomid");

                entity.Property(e => e.Startdate)
                    .HasColumnName("startdate")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Holiday)
                    .HasForeignKey(d => d.Eventid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("holiday_ibfk_1");

                entity.HasOne(d => d.Klient)
                    .WithMany(p => p.Holiday)
                    .HasForeignKey(d => d.Klientid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("holiday_ibfk_3");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Holiday)
                    .HasForeignKey(d => d.Roomid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("holiday_ibfk_2");
            });

            modelBuilder.Entity<Holidayfursh>(entity =>
            {
                entity.ToTable("holidayfursh");

                entity.HasIndex(e => e.Furshid)
                    .HasName("furshid");

                entity.HasIndex(e => e.Holidayid)
                    .HasName("holidayid");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Count)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Furshid).HasColumnName("furshid");

                entity.Property(e => e.Holidayid).HasColumnName("holidayid");

                entity.HasOne(d => d.Fursh)
                    .WithMany(p => p.Holidayfursh)
                    .HasForeignKey(d => d.Furshid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("holidayfursh_ibfk_2");

                entity.HasOne(d => d.Holiday)
                    .WithMany(p => p.Holidayfursh)
                    .HasForeignKey(d => d.Holidayid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("holidayfursh_ibfk_1");
            });

            modelBuilder.Entity<Holidayservices>(entity =>
            {
                entity.ToTable("holidayservices");

                entity.HasIndex(e => e.Holidayid)
                    .HasName("holidayid");

                entity.HasIndex(e => e.Servicesid)
                    .HasName("servicesid");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Holidayid).HasColumnName("holidayid");

                entity.Property(e => e.Servicesid).HasColumnName("servicesid");

                entity.HasOne(d => d.Holiday)
                    .WithMany(p => p.Holidayservices)
                    .HasForeignKey(d => d.Holidayid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("holidayservices_ibfk_1");

                entity.HasOne(d => d.Services)
                    .WithMany(p => p.Holidayservices)
                    .HasForeignKey(d => d.Servicesid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("holidayservices_ibfk_2");
            });

            modelBuilder.Entity<Klient>(entity =>
            {
                entity.ToTable("klient");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Fullname)
                    .IsRequired()
                    .HasColumnName("fullname")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasColumnType("varchar(11)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("room");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cost).HasColumnName("cost");

                entity.Property(e => e.Descriptions)
                    .IsRequired()
                    .HasColumnName("descriptions")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Nameroom)
                    .IsRequired()
                    .HasColumnName("nameroom")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Persons)
                    .IsRequired()
                    .HasColumnName("persons")
                    .HasColumnType("varchar(11)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Photo).HasColumnName("photo");
            });

            modelBuilder.Entity<Services>(entity =>
            {
                entity.ToTable("services");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cost).HasColumnName("cost");

                entity.Property(e => e.Nameservices)
                    .IsRequired()
                    .HasColumnName("nameservices")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
