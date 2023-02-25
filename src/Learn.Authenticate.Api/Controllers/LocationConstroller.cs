using Learn.Authenticate.Api.Filters;
using Learn.Authenticate.Biz.Managers.Interfaces;
using Learn.Authenticate.Entity.Model;
using Learn.Authenticate.Shared.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Learn.Authenticate.Api.Controllers
{
    [Route("api/location")]
    [ApiController]
    [Authorize]
    public class LocationController : ControllerBase
    {
        private readonly ILocationManager _locationManager;

        public LocationController(
            ILocationManager locationManager
        )
        {
            _locationManager = locationManager;
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok(await _locationManager.GetByIdAsync(id));
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetListAsync([FromQuery] LocationBasePageInputModel input)
        {
            return Ok(await _locationManager.GetListAsync(input));
        }

        [HttpPost]
        [ServiceFilter(typeof(AdminRoleFilter))]
        public async Task<IActionResult> CreateAsync([FromBody] LocationInputModel input)
        {
            await _locationManager.CreateAsync(input, User.Claims.GetUserId());
            return Ok();
        }

        [HttpPut]
        [ServiceFilter(typeof(AdminRoleFilter))]
        public async Task<IActionResult> UpdateAsync([FromBody] LocationInputModel input)
        {
            await _locationManager.UpdateAsync(input, User.Claims.GetUserId());
            return Ok();
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(AdminRoleFilter))]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] LocationInputModel input)
        {
            await _locationManager.UpdateAsync(input, User.Claims.GetUserId());
            return Ok();
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(AdminRoleFilter))]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _locationManager.DeleteAsync(id);
            return Ok();
        }
    }
}
