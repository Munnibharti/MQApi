using HotelManagementProjectfeb.Model.Domain;

namespace HotelManagementProjectfeb.Repositories
{
    public interface IUserRepository
    {
        Task<User> AuthenticateAsync(string username, string password);
    }
}
