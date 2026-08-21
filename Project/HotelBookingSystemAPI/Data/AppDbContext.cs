using HotelBookingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingSystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
        }

        public DbSet<Hotel> Hotels => Set<Hotel>();
        public DbSet<Reservation> Reservations => Set<Reservation>();
        public DbSet<Room> Rooms => Set<Room>();
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<ReservationRoom> ReservationRooms => Set<ReservationRoom>();
        public DbSet<Billing> Billing => Set<Billing>();
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>()
                .HasMany(h => h.Rooms)
                .WithOne(r => r.Hotel)
                .HasForeignKey(r => r.HotelId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Reservations)
                .WithOne(r => r.Customer)
                .HasForeignKey(r => r.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Reservation>()
                .HasMany(r => r.ReservationRooms)
                .WithOne(rr => rr.Reservation)
                .HasForeignKey(rr => rr.ReservationId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Room>()
                .HasMany(r => r.ReservationRooms)
                .WithOne(rr => rr.Room)
                .HasForeignKey(rr => rr.RoomId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Billing>()
                .HasIndex(c => c.ReservationId)
                .IsUnique();

            modelBuilder.Entity<Billing>()
                .Property(b => b.Total_Ammount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Reservation>()
                .HasIndex(c => new { c.CustomerId, c.Created_At })
                .IsUnique();

            modelBuilder.Entity<Customer>()
                .HasIndex(c => c.Email)
                .IsUnique();

            modelBuilder.Entity<Hotel>()
                .HasIndex(c => new { c.HotelName, c.City })
                .IsUnique();

            modelBuilder.Entity<Room>()
                .HasIndex(r => new { r.HotelId, r.Room_Number })
                .IsUnique();
            modelBuilder.Entity<User>().HasData(
               new User
               {
                   Id = 1,
                   UserName = "admin",
                   Password = "1234",
                   Role = "Admin"
               },
               new User
               {
                   Id = 2,
                   UserName = "user1",
                   Password = "1234",
                   Role = "Customer"
               }
           );
        }
    }
}
