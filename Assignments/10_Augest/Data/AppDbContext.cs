using _10_Augest.Models;
using Microsoft.EntityFrameworkCore;

namespace _10_Augest.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Passenger> Passengers => Set<Passenger>();

        public DbSet<Bus> Buses => Set<Bus>();

        public DbSet<State> States => Set<State>();

        public DbSet<Booking> Bookings => Set<Booking>();


        // automobile tables are created

        public DbSet<Customer> Customers => Set<Customer>();

        public DbSet<Company> Companies => Set<Company>();

        public DbSet<Vehicle> Vehicles => Set<Vehicle>();

        public DbSet<Purchase> Purchases => Set<Purchase>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>().HasOne(b => b.Passenger).WithMany().HasForeignKey(b => b.PassengerId);

            modelBuilder.Entity<Booking>().HasOne(b => b.Bus).WithMany().HasForeignKey(b => b.BusId);           

            modelBuilder.Entity<Booking>().HasOne(b => b.State).WithMany().HasForeignKey(b => b.StateId);


            // Relationship between Automobile Properties such as 

            modelBuilder.Entity<Vehicle>()
    .HasOne<Company>()
    .WithMany()
    .HasForeignKey(v => v.CompanyId);

            modelBuilder.Entity<Purchase>()
                .HasOne<Customer>()
                .WithMany()
                .HasForeignKey(p => p.CustomerId);

            modelBuilder.Entity<Purchase>()
                .HasOne<Vehicle>()
                .WithMany()
                .HasForeignKey(p => p.VehicleId);

            modelBuilder.Entity<Vehicle>()
                .Property(v => v.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Purchase>()
                .Property(p => p.Price)
                .HasPrecision(18, 2);


            //prevent the same seat from being booked twice
            modelBuilder.Entity<Booking>().HasIndex(b => new { b.BusId, b.TravelDate, b.SeatNumber }).IsUnique();

          // ensure the unique ness of each propertyies of Automobile


            modelBuilder.Entity<Customer>()
    .HasIndex(c => c.Email)
    .IsUnique();

            modelBuilder.Entity<Company>()
                .HasIndex(c => c.CompanyName)
                .IsUnique();

            modelBuilder.Entity<Vehicle>()
                .HasIndex(v => new { v.CompanyId, v.VehicleName })
                .IsUnique();

            modelBuilder.Entity<Purchase>()
                .HasIndex(p => new { p.CustomerId, p.VehicleId, p.PurchaseDate })
                .IsUnique();

        }
    }
}