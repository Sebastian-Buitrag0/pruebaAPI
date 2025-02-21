using Microsoft.AspNetCore.Mvc;
using pruebaAPI.Models;
using pruebaAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace pruebaAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class RolController(IRoleRepository roleRepository) : ControllerBase
    {
        private readonly IRoleRepository _roleRepository = roleRepository;

        [HttpGet]
        public ActionResult<IEnumerable<RoleResponse>> Get()
        {
            return Ok(_roleRepository.GetRoles());
        }

        [HttpGet("{id}")]
        public ActionResult<RoleResponse> Get(Guid id)
        {
            var rol = _roleRepository.GetRole(id);
            if (rol == null)
                return NotFound();

            return Ok(rol);
        }

        [HttpPost]
        public ActionResult Add([FromBody] RoleRequest rol)
        {
            var result = _roleRepository.AddRole(rol);
            // Assume RolRequest has an Id property defined when the role is created
            return CreatedAtAction(nameof(Get), new { id = result.Id }, rol);
        }

        [HttpPut("{id}")]
        public ActionResult Update(Guid id, [FromBody] RoleRequest request)
        {
            var existingRol = _roleRepository.GetRole(id);
            if (existingRol == null || id != existingRol.Id)
            {
                return BadRequest();
            }

            _roleRepository.UpdateRole(id, request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var rol = _roleRepository.GetRole(id);
            if (rol == null)
                return NotFound();

            _roleRepository.DeleteRole(id);
            return NoContent();
        }
    }
}