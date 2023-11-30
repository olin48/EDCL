using EDCL.WebAPI.Data.Models;

namespace EDCL.WebAPI.Data.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Products>> GetProducts();

    }
}
