using karavana_CONTRACTS.DTOs.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace karavana_APPLICATION.ServiceAbstractions
{
    public interface ICompanyService
    {
        Task<CompanyDto> CreateCompany(CompanyCreateRequest request);
        Task<CompanyDto?> GetCompanyById(int id);   
    }
}
