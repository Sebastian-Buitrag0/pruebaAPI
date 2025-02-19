using pruebaAPI.Models;

namespace pruebaAPI.Repositories
{
    public interface IUserRespoitory
    {
        IEnumerable<User> GetUsers();
        UserResponse GetUser(Guid id);
        UserResponse AddUser(UserRequest user);
        void UpdateUser(Guid id, UserRequest user);
        void DeleteUser(Guid id);

    }
}