using Microsoft.IdentityModel.Tokens;
using MQApi.Web.Model.Domain;

namespace MQApi.Web.Repositories
{
    public interface IUserRepository
    {
      Task<User>  AuthenticateAsync(string username, string password);
    }
}
