using CodingChallenge.DTO;
using CodingChallenge.Interfaces;
using CodingChallenge.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodingChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
     

        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            try
            {
                var products = _productRepository.GetAllProducts();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            try
            {
                _productRepository.AddProduct(product);
                return Ok("Product added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPut("UpdatePrice")]  
        public IActionResult UpdatePrice(PriceUpdateDto priceUpdate)
        {
            try
            {
                _productRepository.UpdateProductPrice(priceUpdate);
                return Ok("Prices updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPut("UpdatePrices")]  
        public IActionResult UpdatePrices(List<PriceUpdateDto> priceUpdates)
        {
            try
            {
                foreach(var priceUpdate in priceUpdates)
                {
                    _productRepository.UpdateProductPrice(priceUpdate);
                }
                return Ok("Prices updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                _productRepository.DeleteProduct(id);
                return Ok("Product deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

    }
}
