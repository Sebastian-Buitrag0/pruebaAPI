using Microsoft.AspNetCore.Mvc;
using pruebaAPI.Models;
using pruebaAPI.Repositories;
using System;
using System.Collections.Generic;

namespace pruebaAPI.Controllers
{   
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CategoryResponse>> Get()
        {
            return Ok(_categoryRepository.GetCategories());
        }

        [HttpGet("{id}")]
        public ActionResult<CategoryResponse> Get(Guid id)
        {
            var category = _categoryRepository.GetCategory(id);
            if (category == null)
                return NotFound();

            return Ok(category);
        }

        [HttpPost]
        public ActionResult Add([FromBody] CategoryRequest category)
        {
            _categoryRepository.AddCategory(category);
            // Se asume que CategoryRequest tiene una propiedad Id definida al crearse la categoría
            return CreatedAtAction(nameof(Get), new { id = category }, category);
        }

        [HttpPut("{id}")]
        public ActionResult Update(Guid id, [FromBody] CategoryRequest request)
        {
            var existingCategory = _categoryRepository.GetCategory(id);
            if (request == null || id != existingCategory.Id)
            {
                return BadRequest();
            }

            _categoryRepository.UpdateCategory(id, request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var category = _categoryRepository.GetCategory(id);
            if (category == null)
                return NotFound();

            _categoryRepository.DeleteCategory(id);
            return NoContent();
        }
    }
}