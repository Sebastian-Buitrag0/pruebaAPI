using pruebaAPI.Data;
using pruebaAPI.Interfaces;
using pruebaAPI.Models;

namespace pruebaAPI.Repositories
{
    public class UserDataRepository(ApplicationDbContext context) : IUserDataRepository
    {
        private readonly ApplicationDbContext _context = context;

        public UserDataResponse AddDataUser(UserDataRequest request)
        {
            var newDataUser = new UserData
            {
                Name = request.Name,
                LastName = request.LastName,
                Birth = request.Birth,
                Email = request.Email,
                Phone = request.Phone
            };

            _context.UsersData.Add(newDataUser);
            _context.SaveChanges();

            return new UserDataResponse
            {
                Id = newDataUser.Id,
                Name = newDataUser.Name,
                LastName = newDataUser.LastName,
                Birth = newDataUser.Birth,
                Email = newDataUser.Email,
                Phone = newDataUser.Phone
            };
        }

        public void DeleteDataUser(Guid id)
        {
            var entity = _context.UsersData.FirstOrDefault(u => u.Id == id);
            if (entity != null)
            {
                _context.UsersData.Remove(entity);
                _context.SaveChanges();
            }
            else
            {
                // Optionally handle not found case.
                throw new ArgumentException("User not found");
            }
        }

        public IEnumerable<UserDataResponse> GetDataUsers()
        {
            return [.. _context.UsersData.Select(user => new UserDataResponse
            {
                Id = user.Id,
                Name = user.Name,
                LastName = user.LastName,
                Birth = user.Birth,
                Email = user.Email,
                Phone = user.Phone
            })];
        }

        public UserDataResponse GetDataUser(Guid id)
        {
            // Assuming User maps to DataUser.
            var entity = _context.UsersData.FirstOrDefault(u => u.Id == id);
            if (entity == null)
            {
                throw new ArgumentException("User not found");
            }
            return new UserDataResponse
            {
                Id = entity.Id,
                Name = entity.Name,
                LastName = entity.LastName,
                Birth = entity.Birth,
                Email = entity.Email,
                Phone = entity.Phone
            };
        }

        public void UpdateDataUser(Guid id, UserDataRequest request)
        {
            var entity = _context.UsersData.FirstOrDefault(u => u.Id == id);
            if (entity == null)
            {
                throw new ArgumentException("User not found");
            }

            entity.Name = request.Name;
            entity.LastName = request.LastName;
            entity.Birth = request.Birth;
            entity.Email = request.Email;
            entity.Phone = request.Phone;

            _context.SaveChanges();
        }

    }
}