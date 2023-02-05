using MQApi.Web.Model.Domain;

namespace MQApi.Web.Repositories
{
    public interface ITokenHandler
    {
        Task<string> CreateTokenAsync(User user);


    }
}
