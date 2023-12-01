using EDCL.WebAPI.Service;
using EDCL.WebAPI.Service.Interfaces;
using EDCL.WebAPI.Services.Interfaces;
using EDCL.WebAPI.Utils.Response;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace EDCL.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DriverController : ControllerBase
    {
        private readonly IDriverService _driverService;
        private readonly ILogger<DriverController> _logger;

        public DriverController(IDriverService driverService, ILogger<DriverController> logger)
        {
            _driverService = driverService;
            _logger = logger;
        }

        [HttpGet("{nohp}")]
        public async Task<IActionResult> GetDriverInfoByNoHP(string nohp)
        {
            try
            {
                var data = await _driverService.GetDriverInfoByNoHP(nohp);
                //int statusCode = data.Status;

                //var response = Response. .CreateResponse((int)HttpStatusCode.OK, $"Data {nohp} ditemukan", data);
                /*
                if (data == null)
                {
                    _logger.LogWarning($"Driver with nohp {nohp} not found.");
                    return NotFound();
                }
                */
                return StatusCode(data.Status, data);

                //return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while retrieving product with NoHP {nohp}.");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
