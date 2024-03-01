using IMAMComputerAPI.Data;
using IMAMComputerAPI.Dto;
using IMAMComputerAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace IMAMComputerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly Context _dbContext;
        public ProductsController(Context dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("GetAllProductsAsync")]
        public async Task<IActionResult> GetAllProducts()
        {
            
            return Ok(await _dbContext.Products.ToListAsync());
        }

        [HttpGet("GetByIdProductAsync")]
        public async Task<IActionResult> GetByIdProduct(Guid id)
        {
            var product = await _dbContext.Products.FindAsync(id);
            if (product != null)
            {
                return Ok(product);
            }
            return NotFound();
        }

        [HttpPost("AddProductAsync")]
        public async Task<IActionResult> AddProduct([FromForm] AddProductDto request)
        {
            var newProduct = new Product()
            {
                ProductID = Guid.NewGuid(),
                ProductName = request.ProductName,
                ProductStock = request.ProductStock,
                ProductPrice = request.ProductPrice,
                ProductDesciption = request.ProductDesciption,
                CategoryID = request.CategoryID,
                BrandID = request.BrandID
            };

            await _dbContext.AddAsync(newProduct);
            await _dbContext.SaveChangesAsync();
            return Ok("ÜRÜN EKLENDİ !!!");
        }

        [HttpPut("UpdateProductAsync")]
        public async Task<IActionResult> UpdateProduct(Guid id, UpdateProductDto updateProductDto)
        {
            var product = await _dbContext.Products.FindAsync(id);
            if (product != null)
            {
                product.ProductName = updateProductDto.ProductName;
                product.ProductStock = updateProductDto.ProductStock;
                product.ProductPrice = updateProductDto.ProductPrice;
                product.ProductDesciption = updateProductDto.ProductDesciption;

                await _dbContext.SaveChangesAsync();
                return Ok(product);
            }
            return NotFound();
        }


        [HttpDelete("DeleteProductAsync")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var product = await _dbContext.Products.FindAsync(id);
            if (product != null)
            {
                _dbContext.Remove(product);
                await _dbContext.SaveChangesAsync();
                return Ok(product);
            }

            return NotFound();
        }
    }
}
