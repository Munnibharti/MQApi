using Microsoft.AspNetCore.Components.Routing;

namespace MQApi.Web.Model.Domain
{
    public class User_Role
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        
        //Navigation Property 
        public User User { get; set; }

        public Guid RoleId { get; set; }
        //Navigation property
        public Role Role { get; set; }
    }
}
