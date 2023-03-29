using Microsoft.EntityFrameworkCore;
using SolidProductApi.Models;

namespace SolidProductApi.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;

        public ProductService(DataContext DataContext)
        {
            _context = DataContext;
        }

        public async Task<ServiceResponse<List<Product>>> GetProductsAsync()
        {
            var serviceResponse = new ServiceResponse<List<Product>>();

            var products = await _context.Products.ToListAsync();
            serviceResponse.Data = products;

            return serviceResponse;
        }

        public async Task<ServiceResponse<Product>> AddProductAsync(Product product)
        {
            var response = new ServiceResponse<Product>();

            product.Id = Guid.NewGuid();

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            response.Data = product;

            return response;
        }

        public async Task<ServiceResponse<Product>> GetProductAsync(Guid id)
        {
            var response = new ServiceResponse<Product>();
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            response.Data = product;
            return response;
        }

        public async Task<ServiceResponse<Product>> EditProductAsync(Product product)
        {
            var response = new ServiceResponse<Product>();
            var productToUpdate = await _context.Products.FirstOrDefaultAsync(p => p.Id == product.Id);
            productToUpdate.Title = product.Title;
            productToUpdate.Description = product.Description;
            productToUpdate.Price = product.Price;
            await _context.SaveChangesAsync();
            response.Data = productToUpdate;
            return response;
        }

        public async Task<ServiceResponse<Product>> DeleteProductAsync(Guid id)
        {
            var response = new ServiceResponse<Product>();
            var productToDelete = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            _context.Products.Remove(productToDelete);
            await _context.SaveChangesAsync();
            response.Data = productToDelete;
            return response;
        }
    }
}
