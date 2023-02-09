using System.ComponentModel.DataAnnotations;

namespace HotelManagementProjectfeb.Model
{
    public class Bill
    {
        [Display]
        public Guid Bill_id { get; set; }

        public int stay_dates { get; set; }

        public double prices { get; set; }

        public List<Room> Rooms { get; set; }


    }
}
