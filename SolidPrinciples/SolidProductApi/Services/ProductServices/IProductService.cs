using SolidProductApi.Models;

namespace SolidProductApi.Services.ProductServices
{
    public interface IProductService
    {
        Task<ServiceResponse<List<Product>>> GetProductsAsync();
        Task<ServiceResponse<Product>> GetProductAsync(Guid id);
        Task<ServiceResponse<Product>> AddProductAsync(Product product);
        Task<ServiceResponse<Product>> EditProductAsync(Product product);
        Task<ServiceResponse<Product>> DeleteProductAsync(Guid id);
    }
}
