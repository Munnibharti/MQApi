using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace HotelManagementProjectfeb.Model.Domain
{
    public class Receptionist
    {
        [Key]
        public Guid Receptionist_Id { get; set; }

        public string Password { get; set; }

        public string name { get; set; }

        public string address { get; set; }

        public double salary { get; set; }
        public Guid Reservation_id { get; set; }

        //navigation property
        public List<Reservation> Reservations { get; set; }

        [ForeignKey("Department")]
        public Guid Department_Id { get; set; }

        //navigation property
        public Department Department { get; set; }

        public Guid Guest_Id { get; set; }

        public List<Guest> Guest { get; set; }

        public Guid room_id { get; set; }

        public List<Room> room { get; set; }

        [ForeignKey("Bill")]
        public Guid bill_id { get; set; }

        public Bill Bill { get; set; }







    }
}
