using Microsoft.EntityFrameworkCore;
using MQApi.Web.Data;
using MQApi.Web.Model.Domain;


namespace MQApi.Web.Repositories
{
    public class WalkDifficultyRepo : _IWalkDifficultyRepository
    {
        private readonly WebApiWalksDbContext webapiwalk;

        public WalkDifficultyRepo(WebApiWalksDbContext webApiWalksDb)
        {
            this.webapiwalk=webApiWalksDb;
        }

        public async Task<WalkDifficulty> AddAsync(WalkDifficulty walkdiff)
        {
            walkdiff.Id = Guid.NewGuid();
            await webapiwalk.AddAsync(walkdiff);
            await webapiwalk.SaveChangesAsync();
            return walkdiff;
        }

        public async Task<WalkDifficulty> DeleteAsync(Guid id)
        {
            var walkdiff = await webapiwalk.WalkDifficulty.FirstOrDefaultAsync(x => x.Id == id);

            if (walkdiff == null)
            {
                return null;
            }
            //Delete the region
            webapiwalk.WalkDifficulty.Remove(walkdiff);

            await webapiwalk.SaveChangesAsync();

            return walkdiff;

        }

        public async Task<IEnumerable<WalkDifficulty>> GetAllAsync()
        {
              return await
              webapiwalk.WalkDifficulty.ToListAsync();
        }

        public async Task<WalkDifficulty> GetAsync(Guid id)
        {
            return await webapiwalk.WalkDifficulty.FirstOrDefaultAsync(x => x.Id == id);
        }

        public  async Task<WalkDifficulty> UpdateWalkdiffAsync(Guid id, WalkDifficulty walk)
        {
            var existingwalk = await webapiwalk.WalkDifficulty.FirstOrDefaultAsync(x => x.Id == id);

            if (existingwalk == null)
            {
                return null;
            }

            existingwalk.Code = walk.Code;

            await webapiwalk.SaveChangesAsync();

            return existingwalk;

        }
    }
}
