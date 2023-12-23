using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Context
{
    public class LRTSContext : DbContext
    {
        private IConfiguration _configuration;

        public LRTSContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public LRTSContext()
        {
            
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<University> Universities { get; set; }
        public virtual DbSet<Library> Libraries { get; set; }
        public virtual DbSet<Block> Blocks { get; set; }
        public virtual DbSet<Floor> Floors { get; set; }
        public virtual DbSet<Desk> Desks { get; set; }
        public virtual DbSet<Scanner> Scanners { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseNpgsql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(user => user.Id).ValueGeneratedOnAdd();
                entity.HasKey(user => user.Id);

                entity.HasOne(user => user.University).WithMany(university => university.Users).HasConstraintName("lnk_User_University").HasPrincipalKey("Id");

                entity.Property(user => user.UserType).HasConversion(
                    ut => ut.ToString(),
                    ut => (UserType)Enum.Parse(typeof(UserType), ut));

                entity.Property(user => user.CurrentUserStatus).HasConversion(
                   cus => cus.ToString(),
                   cus => (UserStatus)Enum.Parse(typeof(UserStatus), cus));

                entity.Property(user => user.PreviousUserStatus).HasConversion(
                   pus => pus.ToString(),
                   pus => (UserStatus)Enum.Parse(typeof(UserStatus), pus));
            });

            modelBuilder.Entity<University>(entity =>
            {
                entity.Property(university => university.Id).ValueGeneratedOnAdd();

                entity.HasMany(university => university.Libraries).WithOne(library => library.University).HasConstraintName("lnk_University_Library");
            });

            modelBuilder.Entity<Library>(entity =>
            {
                entity.Property(library => library.Id).ValueGeneratedOnAdd();
                entity.HasMany(library => library.Blocks).WithOne(block => block.Library).HasConstraintName("lnk_Library_Block");

            });

            modelBuilder.Entity<Block>(entity =>
            {
                entity.Property(block => block.Id).ValueGeneratedOnAdd();

                entity.HasMany(block => block.Floors).WithOne(floor => floor.Block).HasConstraintName("lnk_Block_Floor");


            });

            modelBuilder.Entity<Floor>(entity =>
            {
                entity.Property(floor => floor.Id).ValueGeneratedOnAdd();
             //   entity.HasMany(floor => floor.Desks).WithOne(desk => desk.Floor).HasConstraintName("lnk_Floor_Desk");

            });

            modelBuilder.Entity<Desk>(entity =>
            {
                entity.Property(desk => desk.Id).ValueGeneratedOnAdd();

                entity.Property(desk => desk.DeskStatus).HasConversion(
                    ds => ds.ToString(),
                    ds => (DeskStatus)Enum.Parse(typeof(DeskStatus), ds));

            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.Property(reservation => reservation.Id).ValueGeneratedOnAdd();

                entity.HasMany(reservation => reservation.Users).WithOne(users => users.Reservation).HasConstraintName("lnk_Reservation_User");
                entity.Property(reservation => reservation.ReservationStatus).HasConversion(
                  rs => rs.ToString(),
                  rs => (ReservationStatus)Enum.Parse(typeof(ReservationStatus), rs));
            });
        }
    }
}
