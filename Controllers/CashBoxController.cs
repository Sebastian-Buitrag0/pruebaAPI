// filepath: /Users/futurodigital005/Desktop/Prosoft/Proyectos/dotnet/pruebaAPI/Controllers/CashMovementsController.cs
using Microsoft.AspNetCore.Mvc;
using pruebaAPI.Models;
using pruebaAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace pruebaAPI.Controllers
{   
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CashMovementsController(ICashMovementsRepository cashMovementsRepository) : ControllerBase
    {
        private readonly ICashMovementsRepository _cashMovementsRepository = cashMovementsRepository;

        [HttpGet]
        public ActionResult<IEnumerable<CashMovementsResponse>> Get()
        {
            return Ok(_cashMovementsRepository.GetCashMovements());
        }

        [HttpGet("{id}")]
        public ActionResult<CashMovementsResponse> Get(Guid id)
        {
            var cashMovements = _cashMovementsRepository.GetCashMovements(id);
            if (cashMovements == null)
                return NotFound();

            return Ok(cashMovements);
        }

        [HttpPost]
        public ActionResult Add([FromBody] CashMovementsRequest request)
        {
            var result = _cashMovementsRepository.AddCashMovements(request);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, request);
        }

        [HttpPut("{id}")]
        public ActionResult Update(Guid id, [FromBody] CashMovementsRequest request)
        {
            var CashMovements = _cashMovementsRepository.GetCashMovements(id);
            if (request == null || id != CashMovements.Id)
            {
                return BadRequest();
            }

            _cashMovementsRepository.UpdateCashMovements(id, request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            _cashMovementsRepository.DeleteCashMovements(id);
            return NoContent();
        }
    }
}