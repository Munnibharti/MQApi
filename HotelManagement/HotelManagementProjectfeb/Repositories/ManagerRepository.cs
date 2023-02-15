using HotelManagementProjectfeb.Data;
using HotelManagementProjectfeb.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementProjectfeb.Repositories
{
    public class ManagerRepository : IManagerRepository
    {
        //using private readonly data types can
        //help promote good programming practices such as encapsulation, immutability,
        //and thread safety, making the resulting code more robust and easier to maintain.
        //here created object HotelManagementDataContext to perform all crud operation.
        private readonly HotelManagementDataContext _db;
        public ManagerRepository(HotelManagementDataContext db)
        {
            _db = db;
        }

        //here it is add more guest so it is work on post method
        public async Task<Manager> AddAsync(Manager manager)
        {
            manager.manager_id = Guid.NewGuid();

            await _db.AddAsync(manager);

            await _db.SaveChangesAsync();

            return manager;

        }


        // here we are deleting basis  on id if id will got then delete other than do not delete
        public async Task<Manager> DeleteAsync(Guid id)

        {
            var manager = await _db.Managers.FirstOrDefaultAsync(x => x.manager_id == id);


            if (manager == null)
            {
                return null;
            }
            //Delete the guest
            _db.Managers.Remove(manager);

            await _db.SaveChangesAsync();

            return manager;

        }

        //here it will show all things
        public async Task<IEnumerable<Manager>> GetAllAsync()
        {
            return await _db.Managers.ToListAsync();

        }
        public async Task<Manager> GetAsync(Guid id)
        {
            return await _db.Managers.FirstOrDefaultAsync(x => x.manager_id == id);

        }
        public async Task<Manager> UpdateAsync(Guid id, Manager manager)
        {
            //here we are making searching is there any id which is existing

            var existingmanager = await _db.Managers.FirstOrDefaultAsync(x => x.manager_id == id);

            if (existingmanager == null)
            {
                return null;
            }

            // here we are updating the all value except id becauses it will remain same

            existingmanager.manager_name = manager.manager_name;

            existingmanager.address = manager.address;

            existingmanager.salary = manager.salary;

            await _db.SaveChangesAsync();

            return existingmanager;

        }
    }
}

