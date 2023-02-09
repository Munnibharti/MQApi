namespace HotelManagementProjectfeb.Model
{
    public class Room
    {
        public Guid room_id { get; set; }

        public Guid guest_id { get; set; }

        //navigation property
        public List<Guest> Guests { get; set; }

        public DateOnly Check_out { get; set; }

        public DateOnly check_in { get; set; }

        public string guest_name { get; set; }

        public Guid reservation_id { get; set; }

        public List<Reservation> Reservations { get; set; }

        public List<Receptionist> Receptionists { get; set; }
    }
}
