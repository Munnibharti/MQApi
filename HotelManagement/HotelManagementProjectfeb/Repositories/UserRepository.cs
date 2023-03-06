using HotelManagementProjectfeb.Data;
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

        public async Task<Staff> AddAsync(Staff staff)
        {
            staff.Id = Guid.NewGuid();

            await _db.AddAsync(staff);

            await _db.SaveChangesAsync();

            return staff;
        }

        public async Task<Staff> AuthenticateAsync(string username, string password)
        {
            var user = await _db.Staffs
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

        public async Task<Staff> DeleteAsync(Guid id)
        {
            var staff = await _db.Staffs.FirstOrDefaultAsync(x => x.Id == id);


            if (staff == null)
            {
                return null;
            }
            //Delete the guest
            _db.Staffs.Remove(staff);

            await _db.SaveChangesAsync();

            return staff;
        }

        public async Task<IEnumerable<Staff>> GetAllAsync()
        {
            return await _db.Staffs.ToListAsync();
        }

        public async Task<Staff> GetAsync(Guid id)
        {
            return await _db.Staffs.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Staff> UpdateAsync(Guid id, Staff staff)
        {
            //here we are making searching is there any id which is existing

            var existingstaff = await _db.Staffs.FirstOrDefaultAsync(x => x.Id == id);

            if (staff == null)
            {
                return null;
            }

            // here we are updating the all value except id becauses it will remain same
            existingstaff.FirstName = staff.FirstName;
            existingstaff.LastName =staff.LastName;
            existingstaff.UserName = staff.UserName;
            existingstaff.Password = staff.Password;

            await _db.SaveChangesAsync();

            return existingstaff;
        }
    }
}
