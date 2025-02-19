using Microsoft.EntityFrameworkCore;
using pruebaAPI.Data;
using pruebaAPI.Models;

namespace pruebaAPI.Repositories
{
    public class UserRepository(ApplicationDbContext context) : IUserRespoitory
    {
        private readonly ApplicationDbContext _context = context;

        public UserResponse AddUser(UserRequest request)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                UserData = request.UserData,
                Username = request.Username,
                Password = request.Password
            };
            _context.Users.Add(user);
            _context.SaveChanges();
            return new UserResponse {
                UserData = user.UserData,
                Id = user.Id,
                Username = user.Username,
                Password = user.Password
            };
        }

        public void DeleteUser(Guid id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException("User not found");
            }
        }

        public UserResponse GetUser(Guid id)
        {
            var user = _context.Users.Include(user => user.UserData).FirstOrDefault(user => user.Id == id) ?? throw new KeyNotFoundException("User not found");
            return new UserResponse {
                UserData = user.UserData,
                Id = user.Id,
                Username = user.Username,
                Password = user.Password
            };
        }

        public IEnumerable<User> GetUsers() =>
            [.. _context.Users];

        public void UpdateUser(Guid id, UserRequest request)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found");
            }

            user.Username = request.Username;
            user.Password = request.Password;

            _context.Users.Update(user);
            _context.SaveChanges();
        }
    }
}