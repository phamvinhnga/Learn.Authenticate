using Learn.Authenticate.Api.Filters;
using Learn.Authenticate.Biz.Managers.Interfaces;
using Learn.Authenticate.Entity.Migrations;
using Learn.Authenticate.Entity.Model;
using Learn.Authenticate.Shared.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Learn.Authenticate.Api.Controllers
{
    [Route("api/post")]
    [ApiController]
    [Authorize]
    public class PostController : ControllerBase
    {
        private readonly IPostManager _postManager;

        public PostController(
            IPostManager postManager
        ) 
        {
            _postManager = postManager;
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok(await _postManager.GetByIdAsync(id));
        }

        [HttpGet]
        [ServiceFilter(typeof(AdminRoleFilter))]
        public async Task<IActionResult> GetListAsync(BasePageInputModel input)
        {
            return Ok(await _postManager.GetListAsync(input));
        }

        [HttpPost]
        //[ServiceFilter(typeof(AdminRoleFilter))]
        [AllowAnonymous]
        public async Task<IActionResult> CreateAsync([FromForm] PostInputModel input)
        {
            await _postManager.CreateAsync(input, User.Claims.GetUserId());
            return Ok();
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(AdminRoleFilter))]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] PostInputModel input)
        {
            await _postManager.UpdateAsync(input, User.Claims.GetUserId());
            return Ok();
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(AdminRoleFilter))]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _postManager.DeleteAsync(id);
            return Ok();
        }
    }
}
