﻿using HotelManagementProjectfeb.Model.Domain;

namespace HotelManagementProjectfeb.Repositories
{
    public class StaticUserRepository : IUserRepository
    {

        private List<User> Users = new List<User>()
        {
      
        };

        

        public async Task<User> AuthenticateAsync(string username, string password)
        {
            //here we are using InvariantCultureIgnoreCase for ignoring upper case or lower case
            //using method syntax
            var user = Users.Find(x => x.UserName.Equals(username, StringComparison.InvariantCultureIgnoreCase) &&
           x.Password == password);

          

            //return user
            return user;
        }
    }
}