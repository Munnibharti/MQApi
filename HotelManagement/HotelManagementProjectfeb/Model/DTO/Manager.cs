using System.ComponentModel.DataAnnotations;

namespace HotelManagementProjectfeb.Model.DTO
{
    public class Manager
    {
        [Key]
        public Guid manager_id { get; set; }

        public string manager_name { get; set; }

        public string address { get; set; }

        public double salary { get; set; }
    }
}
