using Microsoft.AspNetCore.Mvc;
using pruebaAPI.Models;
using pruebaAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace pruebaAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserDataController(IUserDataRepository userDataRepository) : ControllerBase
    {
        private readonly IUserDataRepository _userDataRepository = userDataRepository;

        [HttpGet]
        public ActionResult<IEnumerable<UserDataResponse>> Get()
        {
            return Ok(_userDataRepository.GetDataUsers());
        }

        [HttpGet("{id}")]
        public ActionResult<UserDataResponse> Get(Guid id)
        {
            var user = _userDataRepository.GetDataUser(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public ActionResult Add([FromBody] UserDataRequest user)
        {
            var result = _userDataRepository.AddDataUser(user);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, user);
        }

        [HttpPut("{id}")]
        public ActionResult Update(Guid id, [FromBody] UserDataRequest request)
        {
            var user = _userDataRepository.GetDataUser(id);
            if (request == null || id != user.Id)
            {
                return BadRequest();
            }

            _userDataRepository.UpdateDataUser(id, request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            _userDataRepository.DeleteDataUser(id);
            return NoContent();
        }
    }
}