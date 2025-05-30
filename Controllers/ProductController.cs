using Microsoft.AspNetCore.Mvc;
using pruebaAPI.Models;
using pruebaAPI.Repositories;

namespace pruebaAPI.Controllers
{   

    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductoRepository _productRepository;

        public ProductController(IProductoRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductResponse>> Get()
        {
            return Ok(_productRepository.GetProducts());
        }

        [HttpGet("{id}")]
        public ActionResult<ProductResponse> Get(Guid id)
        {
            var producto = _productRepository.GetProduct(id);
            if (producto == null)
                return NotFound();

            return Ok(producto);
        }

        [HttpPost]
        public ActionResult Add([FromBody] ProductRequest product)
        {
            _productRepository.AddProduct(product);
            return CreatedAtAction(nameof(Get), new {id = product}, product);
        }

        [HttpPut("{id}")]
        public ActionResult Update(Guid id, [FromBody] ProductRequest request)
        {
            var product = _productRepository.GetProduct(id);
            if(request == null || id != product.Id)
            {
                return BadRequest();
            }

            _productRepository.UpdateProduct(id, request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            _productRepository.DeleteProduct(id);
            return NoContent();
        }
    }
}