using HotelManagementProjectfeb.Model;

namespace HotelManagementProjectfeb.Data
{
    public class HotelManagementDataContext:DbContext
    {
        public HotelManagementDataContext(DbContextOptions<HotelManagementDataContext> options):base(options)
        {

        }
        public DbSet<Reservation> Reservation { get; set; }

        public DbSet<Manager> Managers { get; set; }

        public DbSet<Receptionist> Receptionists { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Inventory> Inventories { get; set; }

        public DbSet<Department> Department { get; set; }

        public DbSet<Bill> Bills { get; set; }

        public DbSet<Guest> Guests { get; set; } 
    }
}
