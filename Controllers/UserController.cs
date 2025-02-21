using Microsoft.AspNetCore.Mvc;
using pruebaAPI.Models;
using pruebaAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace pruebaAPI.Controllers
{   [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(IUserRespoitory userRepository) : ControllerBase
    {
        private readonly IUserRespoitory _userRepository = userRepository;

        [HttpGet]
        public ActionResult<IEnumerable<UserResponse>> Get()
        {
            return Ok(_userRepository.GetUsers());
        }

        [HttpGet("{id}")]
        public ActionResult<UserResponse> Get(Guid id)
        {
            var user = _userRepository.GetUser(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [NonAction]
        public ActionResult<UserResponse> ValidateUser(Guid id)
        {
            var user = _userRepository.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public ActionResult Add([FromBody] UserRequest user)
        {
            var result = _userRepository.AddUser(user);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, user);
        }

        [HttpPut("{id}")]
        public ActionResult Update(Guid id, [FromBody] UserRequest request)
        {
            var user = _userRepository.GetUser(id);
            if (user == null || id != user.Id)
                return BadRequest();

            _userRepository.UpdateUser(id, request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            _userRepository.DeleteUser(id);
            return NoContent();
        }
    }
}