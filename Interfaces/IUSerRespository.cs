using pruebaAPI.Models;

namespace pruebaAPI.Repositories
{
    public interface IUserRespository
    {
        IEnumerable<User> GetUsers();
        User GetUser(Guid id);
        void AddUser(UserRequest user);
        void UpdateUser(Guid id, UserRequest user);
        void DeleteUser(Guid id);

    }
}