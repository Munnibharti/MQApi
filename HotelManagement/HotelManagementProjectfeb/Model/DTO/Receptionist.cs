using System.ComponentModel.DataAnnotations;

namespace HotelManagementProjectfeb.Model.DTO
{
    public class Receptionist
    {
        [Key]
        public Guid Receptionist_Id { get; set; }

        public string Receptionist_Name { get; set; }
        public string address { get; set; }

        public double salary { get; set; }
    
}
}
