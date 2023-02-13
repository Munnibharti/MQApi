using System.ComponentModel.DataAnnotations;

namespace HotelManagementProjectfeb.Model.Domain
{
    public class Room
    {
        [Key]
        public Guid room_id { get; set; }

        public double room_rate { get; set; }

        public bool room_status  { get; set; }

       

      

       
    }
}
