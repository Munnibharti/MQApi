using MQApi.Web.Model.Domain;

namespace MQApi.Web.Repositories
{
	public interface IRegionRepository
	{
        //IEnumerable<Region> GetAll();

        //We are changing its name to asynchronous
       Task <IEnumerable<Region>> GetAllAsync();
    }
}
