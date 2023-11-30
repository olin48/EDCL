using EDCL.WebAPI.Service;
using EDCL.WebAPI.Service.Interfaces;
using EDCL.WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
                var driver = await _driverService.GetDriverInfoByNoHP(nohp);

                if (driver == null)
                {
                    _logger.LogWarning($"Driver with nohp {nohp} not found.");
                    return NotFound();
                }

                return Ok(driver);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while retrieving product with NoHP {nohp}.");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
