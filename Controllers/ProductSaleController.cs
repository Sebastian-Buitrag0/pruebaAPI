using Microsoft.AspNetCore.Mvc;
using pruebaAPI.Interfaces;
using pruebaAPI.Models; // Asegúrate de tener definidos los modelos ProductSaleRequest y ProductSaleResponse

namespace pruebaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductSaleController(IProductSale productSaleRepository) : ControllerBase
    {
        private readonly IProductSale _productSaleRepository = productSaleRepository;

        // GET: api/ProductSale
        [HttpGet]
        public ActionResult<IEnumerable<ProductSaleResponse>> Get()
        {
            var productSales = _productSaleRepository.GetProductSales();
            return Ok(productSales);
        }
        
        // GET: api/ProductSale/{id}
        [HttpGet("{id}")]
        public ActionResult<ProductSaleResponse> Get(Guid id)
        {
            var sale = _productSaleRepository.GetProductSale(id);
            if (sale == null)
                return NotFound();

            return Ok(sale);
        }

        // POST: api/ProductSale
        [HttpPost]
        public ActionResult Add([FromBody] ProductSaleRequest sale)
        {
            var result = _productSaleRepository.AddProductSale(sale);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, sale);
        }

        // PUT: api/ProductSale/{id}
        [HttpPut("{id}")]
        public ActionResult Update(Guid id, [FromBody] ProductSaleRequest saleRequest)
        {
            var existingSale = _productSaleRepository.GetProductSale(id);
            if (existingSale == null || id != existingSale.Id)
            {
                return BadRequest();
            }

            _productSaleRepository.UpdateProductSale(id, saleRequest);
            return NoContent();
        }

        // DELETE: api/ProductSale/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var sale = _productSaleRepository.GetProductSale(id);
            if (sale == null)
                return NotFound();

            _productSaleRepository.DeleteProductSale(id);
            return NoContent();
        }
    }
}