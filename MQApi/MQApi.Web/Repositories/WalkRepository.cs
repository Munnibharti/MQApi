using Microsoft.EntityFrameworkCore;
using MQApi.Web.Data;
using MQApi.Web.Model.Domain;



namespace MQApi.Web.Repositories
{
    public class WalkRepository: IWalkRepositroy
    {
        private readonly WebApiWalksDbContext webapiwalk;

        public WalkRepository(WebApiWalksDbContext WebApiWalks)
        {
            this.webapiwalk = WebApiWalks;
        }

        public async Task<Model.Domain.Walk> AddAsync(Walk walk)
        {
            walk.Id = Guid.NewGuid();
            await webapiwalk.AddAsync(walk);
            await webapiwalk.SaveChangesAsync();
            return walk;
        }

        public async Task<Walk> DeleteAsync(Guid id)
        {
            var walk = await webapiwalk.Walks.FirstOrDefaultAsync(x => x.Id == id);

            if (walk == null)
            {
                return null;
            }
            //Delete the region
            webapiwalk.Walks.Remove(walk);

            await webapiwalk.SaveChangesAsync();

            return walk;
        }

        public async Task<IEnumerable<Walk>> GetAllAsync()
        {
            //formaking it asynchronously

           
           return await 
                webapiwalk.Walks
                .Include(x=>x.Region)
                .Include(x=>x.WalkDifficulty)
                .ToListAsync();
        }

        public async Task<Walk> GetAsync(Guid id)
        {
            return await webapiwalk.Walks
                .Include(x=>x.Region)
                .Include(x=>x.WalkDifficulty)
                .FirstOrDefaultAsync(x => x.Id == id);

        }

        public  async Task<Walk> UpdateWalkAsync(Guid id, Walk walk)
        {
            var existingwalk = await webapiwalk.Walks.FirstOrDefaultAsync(x => x.Id == id);

            if (existingwalk == null)
            {
                return null;
            }

            existingwalk.Name = walk.Name;

            existingwalk.Length = walk.Length;

            existingwalk.RegionId = walk.RegionId;

            existingwalk.WalkDifficultyId = walk.WalkDifficultyId;



            await webapiwalk.SaveChangesAsync();

            return existingwalk;

        }

        
    }
}
