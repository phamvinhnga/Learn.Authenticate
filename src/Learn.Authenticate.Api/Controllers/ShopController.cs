using Learn.Authenticate.Api.Filters;
using Learn.Authenticate.Biz.Managers.Interfaces;
using Learn.Authenticate.Entity.Migrations;
using Learn.Authenticate.Entity.Model;
using Learn.Authenticate.Shared.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Learn.Authenticate.Api.Controllers
{
    [Route("api/shop")]
    [ApiController]
    [Authorize]
    public class ShopController : ControllerBase
    {
        private readonly IShopManager _shopManager;

        public ShopController(
            IShopManager ShopManager
        )
        {
            _shopManager = ShopManager;
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok(await _shopManager.GetByIdAsync(id));
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetListAsync([FromQuery] ShopPageInputModel input)
        {
            return Ok(await _shopManager.GetListAsync(input));
        }

        [HttpPost]
        [ServiceFilter(typeof(AdminRoleFilter))]
        public async Task<IActionResult> CreateAsync([FromBody] ShopInputModel input)
        {
            await _shopManager.CreateAsync(input, User.Claims.GetUserId());
            return Ok();
        }

        [HttpPut]
        [ServiceFilter(typeof(AdminRoleFilter))]
        public async Task<IActionResult> UpdateAsync([FromBody] ShopInputModel input)
        {
            await _shopManager.UpdateAsync(input, User.Claims.GetUserId());
            return Ok();
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(AdminRoleFilter))]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] ShopInputModel input)
        {
            await _shopManager.UpdateAsync(input, User.Claims.GetUserId());
            return Ok();
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(AdminRoleFilter))]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _shopManager.DeleteAsync(id);
            return Ok();
        }
    }
}
