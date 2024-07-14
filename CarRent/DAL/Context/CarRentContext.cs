using CarRent.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarRent.DAL.Context
{
    public class CarRentContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-493DFJA\\SQLEXPRESS; initial catalog=CarRentDb1;integrated security=true");
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Admin> Admins { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Car>()
            //    .HasOne(c => c.Brand)
            //    .WithMany(b => b.Cars)
            //    .HasForeignKey(c => c.BrandID)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Reservation>()
            //    .HasOne(r => r.Car)
            //    .WithMany()
            //    .HasForeignKey(r => r.CarID)
            //    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.PickUpLocation)
                .WithMany()
                .HasForeignKey(r => r.PickUpLocationID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.DropOffLocation)
                .WithMany()
                .HasForeignKey(r => r.DropOffLocationID)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
