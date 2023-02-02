using MQApi.Web.Model.Domain;


namespace MQApi.Web.Repositories
{
	public interface IRegionRepository
	{
        //IEnumerable<Region> GetAll();

        //We are changing its name to asynchronous
       Task <IEnumerable<Region>> GetAllAsync();
        //After this goes to RegionRepository class

        Task<Region> GetAsync(Guid id);

       Task<Region> AddAsync(Region region);

        Task<Region> DeleteAsync(Guid id);

        Task<Region> UpdateRegionAsync(Guid id, Region region);
    }
}
