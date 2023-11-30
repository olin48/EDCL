using EDCL.WebAPI.Data.DTOs;
using EDCL.WebAPI.Data.Models;

namespace EDCL.WebAPI.Data.Repositories.Interfaces
{
    public interface IDriverRepository
    {
        Task<IEnumerable<DriverInfoDto>> FindDriverInfoByNoHP(string nohp);
    }
}
