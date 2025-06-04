using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Transporteo.DTOs.PaymentMethod;
using Transporteo.Services.Interfaces;

namespace Transporteo.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/admin/payment-methods")]
    [ApiController]
    public class AdminPaymentMethodsController : ControllerBase
    {
        private readonly IPaymentMethodService _service;

        public AdminPaymentMethodsController(IPaymentMethodService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpPost]
        public async Task<IActionResult> Create(PaymentMethodCreateDto dto) => Ok(await _service.CreateAsync(dto));
    }

}
