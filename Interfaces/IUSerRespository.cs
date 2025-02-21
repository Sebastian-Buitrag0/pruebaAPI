using pruebaAPI.Models;

namespace pruebaAPI.Interfaces
{
    public interface IUserRespoitory
    {
        IEnumerable<UserResponse> GetUsers();
        UserResponse GetUser(Guid id);
        UserResponse AddUser(UserRequest user);
        void UpdateUser(Guid id, UserRequest user);
        void DeleteUser(Guid id);
        UserResponse ValidateUser(string username, string password);

    }
}