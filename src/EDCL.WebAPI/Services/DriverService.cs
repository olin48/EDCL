using EDCL.WebAPI.Data.DTOs;
using EDCL.WebAPI.Data.Repositories;
using EDCL.WebAPI.Data.Repositories.Interfaces;
using EDCL.WebAPI.Service;
using EDCL.WebAPI.Utils.Response;
using EDCL.WebAPI.Services.Interfaces;
using System.Xml;
using System;
using Newtonsoft.Json;
using System.Net;
using System.Collections.Generic;
using System.Linq;



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

        public async Task <BaseResponse<IEnumerable<DriverInfoDto>>> GetDriverInfoByNoHP(string nohp)
        {
            try
            {
                var data = await _driverRepository.FindDriverInfoByNoHP(nohp);

                BaseResponse<IEnumerable<DriverInfoDto>> response;

                if (data == null)
                {
                    response = Response.CreateResponse((int)HttpStatusCode.BadRequest, $"Data {nohp} ditemukan", data);
                } else {
                    
                    if (data.Count() == 0) {
                        response = Response.CreateResponse((int)HttpStatusCode.NotFound, $"Data {nohp} ditemukan", data);
                    } else {
                        response = Response.CreateResponse((int)HttpStatusCode.OK, $"Data {nohp} ditemukan", data);
                    }
                }



                // Mengkonversi hasil ke format JSON menggunakan JSON.NET
                //string jsonResult = JsonConvert.SerializeObject(response, Newtonsoft.Json.Formatting.Indented);


                //return await _driverRepository.FindDriverInfoByNoHP(nohp);
                return response; // Response.CreateResponse((int)HttpStatusCode.OK, $"Data {nohp} ditemukan", data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in DriverService.GetDriverInfoByNoHP with NoHP {nohp}");
                throw;
            }
        }
    }
}
