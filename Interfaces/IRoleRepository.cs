using pruebaAPI.Models;

namespace pruebaAPI.Interfaces
{
    public interface IRoleRepository
    {
        IEnumerable<RoleResponse> GetRoles();
        RoleResponse GetRole(Guid id);
        RoleResponse AddRole(RoleRequest request);
        void UpdateRole(Guid id, RoleRequest request);
        void DeleteRole(Guid id);
    }
}