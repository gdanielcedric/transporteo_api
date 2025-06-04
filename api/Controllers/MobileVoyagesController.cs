using Microsoft.AspNetCore.Mvc;
using Transporteo.Services.Interfaces;

namespace Transporteo.Controllers
{
    [Route("api/mobile/voyages")]
    [ApiController]
    public class MobileVoyagesController : ControllerBase
    {
        private readonly IVoyageService _service;

        public MobileVoyagesController(IVoyageService service) => _service = service;
    }

}
