using EDCL.WebAPI.Data.Models;
using EDCL.WebAPI.Data.Repositories.Interfaces;
using EDCL.WebAPI.Service.Interfaces;

namespace EDCL.WebAPI.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductService> _logger;

        public ProductService(IProductRepository productRepository, ILogger<ProductService> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<Products>> GetProducts()
        {
            try
            {
                return await _productRepository.GetProducts();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in ProductService.GetProducts");
                throw;
            }
        }

        /*
        public async Task<Product> GetProductById(int id)
        {
            try
            {
                return await _productRepository.GetProductById(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in ProductService.GetProductById with id {id}");
                throw;
            }
        }

        public async Task<int> AddProduct(Product product)
        {
            try
            {
                return await _productRepository.AddProduct(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in ProductService.AddProduct");
                throw;
            }
        }
        */
    }
}
