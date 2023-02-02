using MQApi.Web.Model.Domain;

namespace MQApi.Web.Repositories
{
    public interface _IWalkDifficultyRepository
    {
        Task <IEnumerable<WalkDifficulty>> GetAllAsync();

        Task<WalkDifficulty> GetAsync(Guid id);

        Task<WalkDifficulty> AddAsync(WalkDifficulty walk);

        Task<WalkDifficulty> UpdateWalkdiffAsync(Guid id, WalkDifficulty walk);

        Task<WalkDifficulty> DeleteAsync(Guid id);
    }
}
