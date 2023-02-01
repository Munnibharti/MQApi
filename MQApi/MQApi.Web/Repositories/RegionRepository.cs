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

		public async Task<Region> AddAsync(Region region)
		{
			region.Id = Guid.NewGuid();
			await webapiwalk.AddAsync(region);
			await webapiwalk.SaveChangesAsync();
			return region;
		}

		public async Task<Region> DeleteAsync(Guid id)
		{
          var region = await  webapiwalk.Regions.FirstOrDefaultAsync(x => x.Id == id);

		  if(region == null)
			{
				return null;
			}
			//Delete the region
			webapiwalk.Regions.Remove(region);

			await webapiwalk.SaveChangesAsync();

			return region;

        }

		public async Task <IEnumerable<Region>> GetAllAsync()
        {
			//formaking it asynchronously

			// return await webapiwalk.Regions.ToListAsync();

			return await webapiwalk.Regions.ToListAsync();
				
		}

		public async Task<Region> GetAsync(Guid id)
		{
		 return  await webapiwalk.Regions.FirstOrDefaultAsync(x=>x.Id == id);

		}

		

		public async  Task<Region> UpdateRegionAsync(Guid id, Region region)
		{
            var existingregion = await webapiwalk.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if (existingregion == null)
            {
                return null;
            }
            
			existingregion.Code = region.Code;

			existingregion.Name = region.Name;

			existingregion.Area = region.Area;

			existingregion.Lat= region.Lat;

			existingregion.Long= region.Long;

			existingregion.Population = region.Population;

            await webapiwalk.SaveChangesAsync();

            return existingregion;

        }
	}
}
