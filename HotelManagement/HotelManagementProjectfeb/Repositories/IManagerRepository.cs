using HotelManagementProjectfeb.Model.Domain;

namespace HotelManagementProjectfeb.Repositories
{
    public interface IManagerRepository
    {
        Task<IEnumerable<Manager>> GetAllAsync();
        //After this goes to RegionRepository class

        Task<Manager> GetAsync(Guid id);

        Task<Manager> AddAsync(Manager manager);

        Task<Manager> DeleteAsync(Guid id);

        Task<Manager> UpdateAsync(Guid id, Manager manager);
    }
}
