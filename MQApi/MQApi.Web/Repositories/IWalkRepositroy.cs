using MQApi.Web.Model.Domain;

namespace MQApi.Web.Repositories
{
    public interface IWalkRepositroy
    {
        Task<IEnumerable<Walk>> GetAllAsync();

        Task<Walk> GetAsync(Guid id);

        Task<Walk> AddAsync(Walk walk);

        Task<Walk> UpdateWalkAsync(Guid id, Walk walk);

        Task<Walk> DeleteAsync(Guid id);
    }
}
