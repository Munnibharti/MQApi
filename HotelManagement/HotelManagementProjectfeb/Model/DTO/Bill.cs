using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementProjectfeb.Model.DTO
{
    public class Bill
    {
        [Key]
        public Guid Bill_id { get; set; }

        public int stay_dates { get; set; }

        //room price = adult*1000+child*500 *stay_dates
        public Guid Room_id { get; set; }


        [ForeignKey("Reservation")]
        public Guid Reservation_id { get; set; }
        public Reservation Reservation { get; set; }


        public List<Room> Rooms { get; set; }
    }
}
