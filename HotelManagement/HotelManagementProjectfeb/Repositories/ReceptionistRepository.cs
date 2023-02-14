using HotelManagementProjectfeb.Data;
using HotelManagementProjectfeb.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementProjectfeb.Repositories
{
    public class ReceptionistRepository:IReceptionistRepositories
    {
        //using private readonly data types can
        //help promote good programming practices such as encapsulation, immutability,
        //and thread safety, making the resulting code more robust and easier to maintain.
        //here created object HotelManagementDataContext to perform all crud operation.
        private readonly HotelManagementDataContext _db;

        public ReceptionistRepository(HotelManagementDataContext db)
        {
            _db = db;
        }


        //here it is add more guest so it is work on post method
        public async Task<Receptionist> AddAsync(Receptionist receptionist)
        {
            receptionist.Receptionist_Id = Guid.NewGuid();

            await _db.AddAsync(receptionist);

            await _db.SaveChangesAsync();

            return receptionist;

        }


        // here we are deleting basis  on id if id will got then delete other than do not delete
        public async Task<Receptionist> DeleteAsync(Guid id)

        {
            var receptionist = await _db.Receptionists.FirstOrDefaultAsync(x => x.Receptionist_Id == id);


            if (receptionist == null)
            {
                return null;
            }
            //Delete the guest
            _db.Receptionists.Remove(receptionist);

            await _db.SaveChangesAsync();

            return receptionist;

        }

        //here it will show all things
        public async Task<IEnumerable<Receptionist>> GetAllAsync()
        {
            return await _db.Receptionists.ToListAsync();

        }
        public async Task<Receptionist> GetAsync(Guid id)
        {
            return await _db.Receptionists.FirstOrDefaultAsync(x => x.Receptionist_Id == id);

        }
        public async Task<Receptionist> UpdateAsync(Guid id, Receptionist receptionist)
        {
            //here we are making searching is there any id which is existing

            var existingreceptionist = await _db.Receptionists.FirstOrDefaultAsync(x => x.Receptionist_Id == id);

            if (existingreceptionist == null)
            {
                return null;
            }

            // here we are updating the all value except id becauses it will remain same

            existingreceptionist.Receptionist_Name = receptionist.Receptionist_Name;

            existingreceptionist.address = receptionist.address;

            existingreceptionist.salary = receptionist.salary;

            await _db.SaveChangesAsync();

            return existingreceptionist;

        }
    }
}