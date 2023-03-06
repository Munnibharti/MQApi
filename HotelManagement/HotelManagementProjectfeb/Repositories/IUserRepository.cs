using HotelManagementProjectfeb.Model.Domain;

namespace HotelManagementProjectfeb.Repositories
{
    public interface IUserRepository
    {
        Task<Staff> AuthenticateAsync(string username, string password);

        Task<IEnumerable<Staff>> GetAllAsync();
        //After this goes to RegionRepository class

        Task<Staff> GetAsync(Guid id);

        Task<Staff> AddAsync(Staff staff);

        Task<Staff> DeleteAsync(Guid id);

        Task<Staff> UpdateAsync(Guid id,Staff staff);
    }
}
