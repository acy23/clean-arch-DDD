using AutoMapper;
using karavana_APPLICATION.InfraAbstractions;
using karavana_APPLICATION.ServiceAbstractions;
using karavana_CONTRACTS.DTOs.Caravan;
using karavana_CONTRACTS.DTOs.Company;
using karavana_DOMAIN.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace karavana_APPLICATION.ServiceImplementations
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _repo;
        private readonly IMapper _mapper;
        public CompanyService(ICompanyRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<CompanyDto> CreateCompany(CompanyCreateRequest request)
        {
            var entity = new Company(request.Name);
            var createdEntity = await _repo.CreateCompany(entity);

            var response = _mapper.Map<CompanyDto>(createdEntity);
            return response;
        }

        public async Task<CompanyDto?> GetCompanyById(int id)
        {
            var item = await _repo.GetCompanyById(id);
            var response = _mapper.Map<CompanyDto>(item);

            return response;
        }
    }
}
