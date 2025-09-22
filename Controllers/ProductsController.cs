using Microsoft.AspNetCore.Mvc;
using Helloapi.Models;
using Helloapi.Data;
using Microsoft.EntityFrameworkCore;
using Helloapi.Services;
using Microsoft.AspNetCore.Authorization;

namespace Helloapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [Authorize(Roles = "User")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Getproducts()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult<Product>> AddProduct(Product product)
        {
            return Ok(await _service.AddAsync(product));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> UpdateProduct(int id, Product updatedProduct)
        {
            if(id != updatedProduct.Id)
            {
                return BadRequest();
            }
            var updated = await _service.UpdateAsync(updatedProduct);
            if (!updated) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
           var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();
            return Ok(deleted);
        } 
    }
}
