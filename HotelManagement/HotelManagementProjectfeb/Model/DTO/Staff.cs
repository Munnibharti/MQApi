using HotelManagementProjectfeb.Model.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagementProjectfeb.Model.DTO
{
    public class Staff
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }
        [NotMapped]
        // represents the roles assigned to the user
        //   [NotMapped] attribute, which means that it is not mapped to a database column.
        public List<string> Roles { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        //Navigation property
        public List<User_Roles> UserRoles { get; set; }

    }
}
