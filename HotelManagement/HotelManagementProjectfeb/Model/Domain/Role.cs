namespace HotelManagementProjectfeb.Model.Domain
{
    public class Role
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        // Navigation property
        //UserRoles, which is a navigation property that represents a one-to-many
        //relationship between Role and User_Roles entities.
        public List<User_Roles> UserRoles { get; set; }
    }
}
