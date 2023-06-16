using GameCollectiblesCore.Users;

namespace GameCollectiblesCore
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
    }
}
