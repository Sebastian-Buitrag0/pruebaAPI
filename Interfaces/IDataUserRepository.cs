using pruebaAPI.Models;

namespace pruebaAPI.Repositories
{

    public interface IDataUserRepository
    {
        IEnumerable<DataUser> GetDataUsers();
        User GetUser(Guid id);
        void AddDataUser(DataUserRequest request);
        void UpdateDataUser(Guid id,DataUserRequest request);
        void DeleteDataUser(Guid id);
    }

}