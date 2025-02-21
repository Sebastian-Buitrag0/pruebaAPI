using Microsoft.AspNetCore.Mvc;
using pruebaAPI.Models;
using pruebaAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace pruebaAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class SaleController(ISaleRepository saleRepository) : ControllerBase
    {
        private readonly ISaleRepository _saleRepository = saleRepository;

        [HttpGet]
        public ActionResult<IEnumerable<SaleResponse>> Get()
        {
            return Ok(_saleRepository.GetSales());
        }

        [HttpGet("{id}")]
        public ActionResult<SaleResponse> Get(Guid id)
        {
            var sale = _saleRepository.GetSale(id);
            if (sale == null)
                return NotFound();

            return Ok(sale);
        }

        [HttpPost]
        public ActionResult Add([FromBody] SaleRequest sale)
        {
            _saleRepository.AddSale(sale);
            return CreatedAtAction(nameof(Get), new { id = sale }, sale);
        }

        [HttpPut("{id}")]
        public ActionResult Update(Guid id, [FromBody] SaleRequest sale)
        {
            var existingSale = _saleRepository.GetSale(id);
            if (existingSale == null)
            {
                return BadRequest();
            }

            _saleRepository.UpdateSale(id, sale);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var sale = _saleRepository.GetSale(id);
            if (sale == null)
                return NotFound();

            _saleRepository.DeleteSale(id);
            return NoContent();
        }
    }
}