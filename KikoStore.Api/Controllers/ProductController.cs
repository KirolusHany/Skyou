using Company.ClassLibrary1;
using KikoStore.Core.Entities;
using KikoStore.Core.Interfaces;
using KikoStore.Core.Specification;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KikoStore.Api.Controllers
{
    public class ProductsController(IUnitOfWork unitOfWork) : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProductsAsync
        ([FromQuery] ProductSpecificationsParams specParams)
        {
            var spec = new ProductSpecification(specParams);
            return await CreatePagedSize(unitOfWork.Repository<Product>(),spec,specParams.PageIndex,specParams.PageSize);
        }
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<string>>> GetBrandsAsync()
        {
            var spec = new BrandListSpecification();
            return Ok(await unitOfWork.Repository<Product>().ListAsync(spec));
        }
        [HttpGet("Types")]
        public async Task<ActionResult<IReadOnlyList<string>>> GetTypesAsync()
        {
            var spec = new TypeListSpecfication();
            return Ok(await unitOfWork.Repository<Product>().ListAsync(spec));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetProductsAsync(int id)
        {
            var product = await unitOfWork.Repository<Product>().GetByIdAsync(id);
            if (product == null) return NotFound("Product not found");

            return product;
        }


        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            unitOfWork.Repository<Product>().Add(product);
            if (await unitOfWork.Complete())
            {
                return CreatedAtAction("GetProduct", new { id = product.Id }, product);
            }
            return BadRequest("prblem in product creation");
        }
        public bool ProductExists(int id)
        {
            return unitOfWork.Repository<Product>().Exists(id);
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateProduct(int id, Product product)
        {
            if (product.Id != id || !ProductExists(id)) return BadRequest("can not updaet product");
            unitOfWork.Repository<Product>().Update(product);
            if (await unitOfWork.Complete())
            {
                return NoContent();
            }
            return BadRequest("prblem in product updating");

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var productFromDb = await unitOfWork.Repository<Product>().GetByIdAsync(id);
            if (productFromDb == null) return NotFound("can not Deleted product");
            unitOfWork.Repository<Product>().Remove(productFromDb);
            if (await unitOfWork.Complete())
            {
                return NoContent();
            }
            return BadRequest("prblem in product deleting");

        }
    }
}
