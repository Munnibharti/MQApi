using HotelManagementProjectfeb.Model.Domain;

namespace HotelManagementProjectfeb.Repositories
{
    public interface IReceptionistRepositories
    {
        Task<IEnumerable<Receptionist>> GetAllAsync();
        //After this goes to RegionRepository class

        Task<Receptionist> GetAsync(Guid id);

        Task<Receptionist> AddAsync(Receptionist receptionist);

        Task<Receptionist> DeleteAsync(Guid id);

        Task<Receptionist> UpdateAsync(Guid id, Receptionist receptionist);
    }
}
