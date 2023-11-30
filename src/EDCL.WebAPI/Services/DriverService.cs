using EDCL.WebAPI.Data.DTOs;
using EDCL.WebAPI.Data.Repositories;
using EDCL.WebAPI.Data.Repositories.Interfaces;
using EDCL.WebAPI.Service;
using EDCL.WebAPI.Services.Interfaces;
using System.Xml;
using System;
using EDCL.WebAPI.Utils.Response;
using Newtonsoft.Json;
using System.Net;

namespace EDCL.WebAPI.Services
{
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository _driverRepository;
        private readonly ILogger<DriverService> _logger;

        public DriverService(IDriverRepository driverRepository, ILogger<DriverService> logger)
        {
            _driverRepository = driverRepository;
            _logger = logger;
        }

        public async Task<BaseResponse<IEnumerable<DriverInfoDto>>> GetDriverInfoByNoHP(string nohp)
        {
            try
            {
                var data = await _driverRepository.FindDriverInfoByNoHP(nohp);

                var driverInfo = new BaseResponse<IEnumerable<DriverInfoDto>>
                {
                    Status = (int)HttpStatusCode.OK,
                    Message = "Data retrieval successful",
                    Data = data
                };

                // Mengkonversi hasil ke format JSON menggunakan JSON.NET
                //string jsonResult = JsonConvert.SerializeObject(response, Newtonsoft.Json.Formatting.Indented);


                //return await _driverRepository.FindDriverInfoByNoHP(nohp);
                return driverInfo;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in DriverService.GetDriverInfoByNoHP with NoHP {nohp}");
                throw;
            }
        }
    }
}
