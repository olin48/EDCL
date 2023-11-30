using EDCL.WebAPI.Data.DTOs;
using EDCL.WebAPI.Utils.Response;

namespace EDCL.WebAPI.Services.Interfaces
{
    public interface IDriverService
    {
        Task<BaseResponse<IEnumerable<DriverInfoDto>>> GetDriverInfoByNoHP(string nohp);
    }
}
