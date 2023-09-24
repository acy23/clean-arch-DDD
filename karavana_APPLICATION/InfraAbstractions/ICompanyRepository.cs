using karavana_DOMAIN.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace karavana_APPLICATION.InfraAbstractions
{
    public interface ICompanyRepository
    {
        Task<Company> CreateCompany(Company company);
        Task<Company?> GetCompanyById(int id);
    }
}
