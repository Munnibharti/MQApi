using System.ComponentModel.DataAnnotations;

namespace HotelManagementProjectfeb.Model.Domain
{
    public class Room
    {
        [Key]
        public Guid room_id { get; set; }

        public Guid guest_id { get; set; }

        //navigation property
        public List<Guest> Guests { get; set; }

        public DateTime Check_out { get; set; }

        public DateTime check_in { get; set; }

        public string guest_name { get; set; }

        public Guid reservation_id { get; set; }

        public List<Reservation> Reservations { get; set; }

        public List<Receptionist> Receptionists { get; set; }
    }
}
