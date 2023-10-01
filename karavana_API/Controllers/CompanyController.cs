using karavana_APPLICATION.ServiceAbstractions;
using karavana_CONTRACTS.DTOs.Company;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace karavana_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _service;
        public CompanyController(ICompanyService service)
        {
            _service = service;
        }

        /// <summary>
        /// Creates a new company.
        /// </summary>
        /// <param name="request">The request object containing company data.</param>
        /// <returns>The created company details.</returns>
        [HttpPost("create")]
        public async Task<CompanyDto> CreateCompany(CompanyCreateRequest request)
        {
            var response = await _service.CreateCompany(request);
            return response;
        }

        [HttpGet("get-by-id")]
        public async Task<CompanyDto> GetCompanyById(int id)
        {
            var response = await _service.GetCompanyById(id);
            return response;
        }
    }
}
