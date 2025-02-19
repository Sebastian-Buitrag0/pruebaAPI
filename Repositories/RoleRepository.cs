using pruebaAPI.Data;
using pruebaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace pruebaAPI.Repositories
{
    public class RolRepository(ApplicationDbContext context) : IRoleRepository
    {
        private readonly ApplicationDbContext _context = context;

        public RoleResponse AddRole(RoleRequest request)
        {
            var rol = new Role
            {
                Name = request.Name,
                Description = request.Description
            };

            _context.Roles.Add(rol);
            _context.SaveChanges();

            return new RoleResponse
            {
                Id = rol.Id,
                Name = rol.Name,
                Description = rol.Description
            };
        }


        public void DeleteRole(Guid id)
        {
            var rol = _context.Roles.Find(id);
            if (rol != null)
            {
                _context.Roles.Remove(rol);
                _context.SaveChanges();
            }
        }

        public RoleResponse GetRole(Guid id)
        {
            var rol = _context.Roles.FirstOrDefault(r => r.Id == id)
                      ?? throw new KeyNotFoundException("Rol not found");
            return new RoleResponse
            {
                Name = rol.Name,
                Description = rol.Description
            };
        }
        public IEnumerable<RoleResponse> GetRoles()
        {
            return _context.Roles.Select(rol => new RoleResponse
            {
                Id = rol.Id,
                Name = rol.Name,
                Description = rol.Description
            }).ToList();
        }

        public void UpdateRole(Guid id, RoleRequest request)
        {
            var rol = _context.Roles.Find(id);
            if (rol != null)
            {
                rol.Name = request.Name;
                rol.Description = request.Description;

                _context.Roles.Update(rol);
                _context.SaveChanges();
            }
        }
    }
}