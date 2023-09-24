using AutoMapper;
using karavana_APPLICATION.InfraAbstractions;
using karavana_DOMAIN.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Data.Entity;

namespace karavana_INFRASTRUCTURE.Persistence.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<CompanyRepository> _logger;
        public CompanyRepository(AppDbContext context, ILogger<CompanyRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<Company> CreateCompany(Company company)
        {
            try
            {
                _context.Add(company);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }

            var item = await GetCompanyById(company.Id);
            return item;
        }

        public async Task<Company?> GetCompanyById(int id)
        {
            var company = await _context.Companys.Where(x => x.Id == id && !x.IsDeleted).SingleOrDefaultAsync();
            return company;
        }
    }
}
