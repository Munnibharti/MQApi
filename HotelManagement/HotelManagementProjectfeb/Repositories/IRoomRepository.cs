using HotelManagementProjectfeb.Model.Domain;

namespace HotelManagementProjectfeb.Repositories
{
    public interface IRoomRepository
    {
        Task<IEnumerable<Guest>> GetAllAsync();
        //After this goes to RegionRepository class

        Task<Guest> GetAsync(Guid id);

        Task<Guest> AddAsync(Guest guest);

        Task<Guest> DeleteAsync(Guid id);

        Task<Guest> UpdateGuestAsync(Guid id, Guest guest);
    }
}
