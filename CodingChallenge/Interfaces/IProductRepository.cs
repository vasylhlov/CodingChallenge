using CodingChallenge.DTO;
using CodingChallenge.Models;

namespace CodingChallenge.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();
        void AddProduct(Product product);
        void UpdateProductPrice(PriceUpdateDto priceUpdateDto);
        void DeleteProduct(int productId);
    }
}
