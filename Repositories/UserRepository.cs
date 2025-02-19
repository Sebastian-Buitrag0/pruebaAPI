using Microsoft.EntityFrameworkCore;
using pruebaAPI.Data;
using pruebaAPI.Interfaces;
using pruebaAPI.Models;

namespace pruebaAPI.Repositories
{
    public class UserRepository(ApplicationDbContext context) : IUserRespoitory
    {
        private readonly ApplicationDbContext _context = context;

        public UserResponse AddUser(UserRequest request)
        {
            var existingRole = _context.Roles.FirstOrDefault(r => r.Id == request.Role)
            ?? throw new KeyNotFoundException("Role not found");

            var user = new User
            {
            Id = Guid.NewGuid(),
            UserData = request.UserData,
            Role = existingRole,
            Username = request.Username,
            Password = request.Password
            };
            _context.Users.Add(user);
            _context.SaveChanges();
            return new UserResponse {
            UserData = user.UserData,
            Role = user.Role,
            Id = user.Id,
            Username = user.Username,
            Password = user.Password
            };
        }

        public void DeleteUser(Guid id)
        {
            var user = _context.Users.Include(u => u.UserData).FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
            
            if (user.UserData != null)
            {
                _context.Remove(user.UserData);
            }
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
            var user = _context.Users
            .Include(user => user.UserData)
            .Include(user => user.Role)
            .FirstOrDefault(user => user.Id == id) 
                ?? throw new KeyNotFoundException("User not found");
            return new UserResponse {
                UserData = user.UserData,
                Role = user.Role,
                Id = user.Id,
                Username = user.Username,
                Password = user.Password
            };
        }

        public IEnumerable<UserResponse> GetUsers() =>
            _context.Users
            .Include(user => user.UserData)
            .Include(user => user.Role)
            .Select(user => new UserResponse { 
                UserData = user.UserData, 
                Role = user.Role,
                Id = user.Id, 
                Username = user.Username, 
                Password = user.Password 
            });

       public void UpdateUser(Guid id, UserRequest request)
{
    var user = _context.Users
        .Include(u => u.UserData)
        .Include(u => u.Role)
        .FirstOrDefault(u => u.Id == id) 
        ?? throw new KeyNotFoundException("User not found");

    if (user.UserData == null)
    {
        throw new NullReferenceException("UserData is null");
    }

    if (request.UserData == null)
    {
        throw new ArgumentNullException(nameof(request.UserData));
    }

    if (request.Role == Guid.Empty)
    {
        throw new ArgumentNullException(nameof(request.Role));
    }

    user.Username = request.Username;
    user.Password = request.Password;

    var dataUser = user.UserData;
    dataUser.Name = request.UserData.Name;
    dataUser.LastName = request.UserData.LastName;
    dataUser.Birth = request.UserData.Birth;
    dataUser.Email = request.UserData.Email;
    dataUser.Phone = request.UserData.Phone;

    var existingRole = _context.Roles.FirstOrDefault(r => r.Id == request.Role)
        ?? throw new KeyNotFoundException("Role not found");

    user.Role = existingRole;
    
    

    _context.Users.Update(user);
    _context.SaveChanges();
}
    }
}