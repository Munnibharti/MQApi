using System.ComponentModel.DataAnnotations;

namespace HotelManagementProjectfeb.Model.Domain
{
    public class Bill
    {
        [Key]
        public Guid Bill_id { get; set; }

        public int stay_dates { get; set; }

        public double prices { get; set; }

        public List<Room> Rooms { get; set; }


    }
}
