using karavana_APPLICATION.ServiceAbstractions;
using karavana_CONTRACTS.DTOs.CaravanRentOffer;
using karavana_CONTRACTS.DTOs.Caravan;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using karavana_CONTRACTS.Models;
using karavana_CONTRACTS.DTOs.Caravan.Requests;

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
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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

        [HttpPost("set-caravan-on-rent")]
        public async Task<CaravanDTO> SetCaravanOnRent([FromBody] SetCravanOnRentRequest request)
        {
            var response = await _service.SetCaravanOnRent(request);
            return response;
        }

        [HttpPut("update-caravan")]
        public async Task<CaravanDTO> UpdateCaravan([FromBody] UpdateCaravanRequest request)
        {
            var response = await _service.UpdateCaravan(request);
            return response;
        }

        [HttpGet("get-caranvans-on-rent-pagination")]
        public async Task<List<CaravanDTO>> GetCaravansOnRentPagination(int page, int pageSize)
        {
            var response = await _service.GetCaravansOnRentPagination(page, pageSize);
            return response;
        }

        [HttpGet("get-caravans-by-companyId-pagination")]
        public async Task<List<CaravanDTO>> GetCaravansByCompanyIdPagination(int companyId, int page, int pageSize)
        {
            var response = await _service.GetCaravansByCompanyIdPagination(companyId, page, pageSize);
            return response;
        }
    }
}
