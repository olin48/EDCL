using EDCL.WebAPI.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EDCL.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }


        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var products = await _productService.GetProducts();

                _logger.LogInformation("Retrieved products successfully.");
                return Ok(products);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while retrieving products.");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
