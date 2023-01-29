using Microsoft.EntityFrameworkCore;
using MQApi.Web.Data;
using MQApi.Web.Model.Domain;

namespace MQApi.Web.Repositories
{
	public class RegionRepository : IRegionRepository
	{
		private readonly WebApiWalksDbContext webapiwalk;

        public RegionRepository(WebApiWalksDbContext WebApiWalks)
		{
			this.webapiwalk = WebApiWalks;
		}

		//public IEnumerable<Region> GetAll()
		//{
		//	//formaking it asynchronously
		//	return webapiwalk.Regions.ToListAsync();
		//	// return webapiwalk.Regions.ToList();

		//}
        public async Task <IEnumerable<Region>> GetAllAsync()
        {
            //formaking it asynchronously

           // return await webapiwalk.Regions.ToListAsync();

             return await webapiwalk.Regions.ToListAsync();

        }

		IEnumerable<Region> IRegionRepository.GetAllAsync()
		{
			throw new NotImplementedException();
		}
	}
}
