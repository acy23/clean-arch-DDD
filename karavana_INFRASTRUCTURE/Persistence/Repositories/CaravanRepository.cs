using karavana_APPLICATION.InfraAbstractions;
using karavana_CONTRACTS.DTOs.Caravan;
using karavana_DOMAIN.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace karavana_INFRASTRUCTURE.Persistence.Repositories
{
    public class CaravanRepository : ICaravanRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<CaravanRepository> _logger;
        public CaravanRepository(AppDbContext context, ILogger<CaravanRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<Caravan> CreateCaravan(Caravan entity)
        {
            await _context.AddAsync(entity);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }

            return await GetCaravanById(entity.Id);
        }

        public async Task<Caravan?> GetCaravanById(int id)
        {
            return await _context.Caravans.Where(x => x.Id == id && !x.IsDeleted).SingleOrDefaultAsync();
        }
    }
}
