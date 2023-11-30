using EDCL.WebAPI.Data.Models;

namespace EDCL.WebAPI.Service.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Products>> GetProducts();
      
    }
}
