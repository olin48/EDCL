using EDCL.WebAPI.Data.DTOs;
using EDCL.WebAPI.Data.Models;

namespace EDCL.WebAPI.Data.Repositories.Interfaces
{
    public interface IDriverRepository
    {
        Task<DriverInfoDto> FindDriverInfoByNoHP(string nohp);
    }
}
