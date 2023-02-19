using HotelManagementProjectfeb.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementProjectfeb.Data
{
    public class HotelManagementDataContext:DbContext
    {
        public HotelManagementDataContext(DbContextOptions<HotelManagementDataContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User_Roles>()
                .HasOne(x => x.Role)
                .WithMany(y => y.UserRoles)
                .HasForeignKey(x => x.RoleId);

            modelBuilder.Entity<User_Roles>()
                .HasOne(x => x.User)
                .WithMany(y => y.UserRoles)
                .HasForeignKey(x => x.UserId);
        }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<Manager> Managers { get; set; }

        public DbSet<Receptionist> Receptionists { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Inventory> Inventories { get; set; }

        public DbSet<Bill> Bills { get; set; }

        public DbSet<Guest> Guests { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User_Roles> Users_Roles { get; set; }
    }




}

