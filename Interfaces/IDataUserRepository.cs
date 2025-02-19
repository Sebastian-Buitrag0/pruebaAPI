using pruebaAPI.Models;

namespace pruebaAPI.Interfaces
{

    public interface IUserDataRepository
    {
        IEnumerable<UserDataResponse> GetDataUsers();
        UserDataResponse GetDataUser(Guid id);
        UserDataResponse AddDataUser(UserDataRequest request);
        void UpdateDataUser(Guid id,UserDataRequest request);
        void DeleteDataUser(Guid id);
    }

}