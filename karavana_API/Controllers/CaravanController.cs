using karavana_APPLICATION.ServiceAbstractions;
using karavana_CONTRACTS.DTOs.Caravan;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace karavana_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaravanController : ControllerBase
    {
        private readonly ICaravanService _service;
        public CaravanController(ICaravanService service)
        {
            _service = service;
        }

        [HttpPost("create")]
        public async Task<CaravanDTO> CreateCaravan([FromBody] CreateCaravanRequest request)
        {
            var response = await _service.CreateCaravan(request);
            return response;
        }

        [HttpGet("get-by-id")]
        public async Task<CaravanDTO> GetCaravanById([FromQuery] int id)
        {
            var response = await _service.GetCaravanById(id);
            return response;
        }

    }
}
