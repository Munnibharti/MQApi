using HotelManagementProjectfeb.Model.Domain;

namespace HotelManagementProjectfeb.Repositories
{
    public class StaticUserRepository : IUserRepository
    {

        private List<User> Users = new List<User>()
        {
        //    new User(){
        //    FirstName = "Receptionist",
        //    LastName = "User",
        //    EmailAddress = "receptionist@user.com",
        //    Id = Guid.NewGuid(),
        //    UserName = "receptionist@user.com",
        //    Password = "receptionist@user",
        //    Roles = new List<string> { "receptionist" }
        //},
        //    new User(){
        //    FirstName = "Manager",
        //    LastName = "User",
        //    EmailAddress = "manager@user.com",
        //    Id = Guid.NewGuid(),
        //   UserName = "manager@user.com",
        //    Password = "manager@user",
        //    Roles = new List<string> { "receptionist","manager" }
        //},
        //     new User(){
        //    FirstName = "Owner",
        //    LastName = "User",
        //    EmailAddress = "owner@user.com",
        //    Id = Guid.NewGuid(),
        //    UserName = "owner@user.com",
        //    Password = "owner@user",
        //    Roles = new List<string> { "receptionist","manager" ,"owner"}
        //}
        };

        

        public async Task<User> AuthenticateAsync(string username, string password)
        {
            //here we are using InvariantCultureIgnoreCase for ignoring upper case or lower case
            //using method syntax
            var user = Users.Find(x => x.UserName.Equals(username, StringComparison.InvariantCultureIgnoreCase) &&
           x.Password == password);

            //if(user!=null)
            //{
            //    return true;
            //}

            //return false;
            return user;
        }
    }
}
