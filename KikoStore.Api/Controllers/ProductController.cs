using KikoStore.Core.Entities;
using KikoStore.Core.Interfaces;
using KikoStore.Core.Specification;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KikoStore.Api.Controllers
{
    public class ProductController(IGenericRepository<Product> _repository) : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProductsAsync
        ([FromQuery] ProductSpecificationsParams specParams)
        {
            var spec = new ProductSpecification(specParams);
            return await CreatePagedSize(_repository,spec,specParams.PageIndex,specParams.PageSize);
        }
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<string>>> GetBrandsAsync()
        {
            var spec = new BrandListSpecification();
            return Ok(await _repository.ListAsync(spec));
        }
        [HttpGet("Types")]
        public async Task<ActionResult<IReadOnlyList<string>>> GetTypesAsync()
        {
            var spec = new TypeListSpecfication();
            return Ok(await _repository.ListAsync(spec));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetProductsAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null) return NotFound("Product not found");

            return product;
        }


        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            _repository.Add(product);
            if (await _repository.SaveChangesAsync())
            {
                return CreatedAtAction("GetProduct", new { id = product.Id }, product);
            }
            return BadRequest("prblem in product creation");
        }
        public bool ProductExists(int id)
        {
            return _repository.IsExsits(id);
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateProduct(int id, Product product)
        {
            if (product.Id != id || !ProductExists(id)) return BadRequest("can not updaet product");
            _repository.Update(product);
            if (await _repository.SaveChangesAsync())
            {
                return NoContent();
            }
            return BadRequest("prblem in product updating");

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var productFromDb = await _repository.GetByIdAsync(id);
            if (productFromDb == null) return NotFound("can not Deleted product");
            _repository.Delete(productFromDb);
            if (await _repository.SaveChangesAsync())
            {
                return NoContent();
            }
            return BadRequest("prblem in product deleting");

        }
    }
}
