using pruebaAPI.Models;

namespace pruebaAPI.Repositories
{

    public interface IUserDataRepository
    {
        IEnumerable<UserData> GetDataUsers();
        UserDataResponse GetUser(Guid id);
        UserDataResponse AddDataUser(UserDataRequest request);
        void UpdateDataUser(Guid id,UserDataRequest request);
        void DeleteDataUser(Guid id);
    }

}