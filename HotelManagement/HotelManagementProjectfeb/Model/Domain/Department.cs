using System.ComponentModel.DataAnnotations;

namespace HotelManagementProjectfeb.Model.Domain
{
    public class Department
    {
        [Key]
        public Guid Department_id { get; set; }

        public string Dapartment_name { get; set; }


    }
}
