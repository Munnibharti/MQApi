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
		//	
		//	// return webapiwalk.Regions.ToList();

		//}
        public async Task <IEnumerable<Region>> GetAllAsync()
        {
            //formaking it asynchronously

           // return await webapiwalk.Regions.ToListAsync();

             return await webapiwalk.Regions.ToListAsync();

        }

		
	}
}
