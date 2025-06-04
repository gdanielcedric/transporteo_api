using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Transporteo.DTOs.User;
using Transporteo.Services.Interfaces;

namespace Transporteo.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/admin/users")]
    [ApiController]
    public class AdminUsersController : ControllerBase
    {
        private readonly IUserService _service;

        public AdminUsersController(IUserService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpPost]
        public async Task<IActionResult> Create(UserCreateDto dto) => Ok(await _service.CreateAsync(dto));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _service.DeleteAsync(id);
            return result ? NoContent() : NotFound();
        }
    }

}
