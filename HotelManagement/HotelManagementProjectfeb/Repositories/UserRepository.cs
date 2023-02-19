﻿using HotelManagementProjectfeb.Data;
using HotelManagementProjectfeb.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementProjectfeb.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly HotelManagementDataContext _db;
        public UserRepository(HotelManagementDataContext db)
        {
            this._db = db;
        }


        public async Task<User> AuthenticateAsync(string username, string password)
        {
            var user = await _db.Users
                .FirstOrDefaultAsync(x => x.UserName.ToLower() == username.ToLower() && x.Password == password);

            if (user == null)
            {
                return null;
            }

            var userRoles = await _db.Users_Roles.Where(x => x.UserId == user.Id).ToListAsync();

            if (userRoles.Any())
            {
                user.Roles = new List<string>();
                foreach (var userRole in userRoles)
                {
                    var role = await _db.Roles.FirstOrDefaultAsync(x => x.Id == userRole.RoleId);
                    if (role != null)
                    {
                        user.Roles.Add(role.Name);
                    }
                }
            }

            user.Password = null;
            return user;
        }
    }
}