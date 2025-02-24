// filepath: /Users/futurodigital005/Desktop/Prosoft/Proyectos/dotnet/pruebaAPI/Controllers/CashBoxController.cs
using Microsoft.AspNetCore.Mvc;
using pruebaAPI.Models;
using pruebaAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace pruebaAPI.Controllers
{   
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CashBoxController(ICashBoxRepository cashBoxRepository) : ControllerBase
    {
        private readonly ICashBoxRepository _cashBoxRepository = cashBoxRepository;

        [HttpGet]
        public ActionResult<IEnumerable<CashBoxResponse>> Get()
        {
            return Ok(_cashBoxRepository.GetCashBoxes());
        }

        [HttpGet("{id}")]
        public ActionResult<CashBoxResponse> Get(Guid id)
        {
            var cashBox = _cashBoxRepository.GetCashBox(id);
            if (cashBox == null)
                return NotFound();

            return Ok(cashBox);
        }

        [HttpPost]
        public ActionResult Add([FromBody] CashBoxRequest request)
        {
            var result = _cashBoxRepository.AddCashBox(request);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, request);
        }

        [HttpPut("{id}")]
        public ActionResult Update(Guid id, [FromBody] CashBoxRequest request)
        {
            var cashBox = _cashBoxRepository.GetCashBox(id);
            if (request == null || id != cashBox.Id)
            {
                return BadRequest();
            }

            _cashBoxRepository.UpdateCashBox(id, request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            _cashBoxRepository.DeleteCashBox(id);
            return NoContent();
        }
    }
}