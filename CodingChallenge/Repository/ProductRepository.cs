using CodingChallenge.DTO;
using CodingChallenge.Interfaces;
using CodingChallenge.Models;

namespace CodingChallenge.Repository
{
    public class ProductRepository : IProductRepository
    {
        private static List<Product> _products = new List<Product>
        {
            //data Seed 
            new Product { Id = 1, Name = "Product 1", Price = 10 },
            new Product { Id = 2, Name = "Product 2", Price = 20 },
            new Product { Id = 3, Name = "Product 3", Price = 30 }
        };

        public List<Product> GetAllProducts()
        {
            return _products;
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }


        public void DeleteProduct(int productId)
        {
            var product = _products.FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                _products.Remove(product);
            }
        }

        public void UpdateProductPrice(PriceUpdateDto priceUpdateDto)
        {
            var product = _products.FirstOrDefault(p => p.Id == priceUpdateDto.ProductId);
            if (product != null)
            {
                product.Price = priceUpdateDto.NewPrice;
            }
        }
    }

}
