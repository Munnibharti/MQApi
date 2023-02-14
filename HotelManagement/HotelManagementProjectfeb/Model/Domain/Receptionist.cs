using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace HotelManagementProjectfeb.Model.Domain
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
