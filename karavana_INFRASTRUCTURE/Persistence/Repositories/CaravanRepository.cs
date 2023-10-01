using karavana_APPLICATION.InfraAbstractions;
using karavana_CONTRACTS.DTOs.Caravan;
using karavana_DOMAIN.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Linq.Expressions;
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

        public async Task<List<Caravan>> GetCaravansOnRentPagination(Expression<Func<Caravan, bool>> predicate, int page, int pageSize)
        {
            var skip = (page - 1) * pageSize;
            var caravans = await _context.Caravans.Where(x => x.CaravanRentOffers.Any())
                                                  .Where(predicate)
                                                  .Skip(skip)
                                                  .Take(pageSize)
                                                  .ToListAsync();

            return caravans;
        }

        public async Task<Caravan?> GetCaravanById(int id)
        {
            return await _context.Caravans.Where(x => x.Id == id && !x.IsDeleted)
                        .Include(x=>x.City)
                        .Include(x=>x.District)
                        .Include(x=>x.Company)
                        .Include(x=>x.CaravanRentOffers)
                        .Include(x=>x.Images)
                        .SingleOrDefaultAsync();
        }

        public async Task<bool> IsCaravanOnRent(int id)
        {
            return await _context.CaravanRentOffers.AnyAsync(x => x.CaravanId == id && !x.IsDeleted);
        }

        public async Task<List<Caravan>> GetCaravans(Expression<Func<Caravan, bool>> predicate, int page, int pageSize)
        {
            var skip = (page - 1) * pageSize;
            return await _context.Caravans.Where(predicate)
                        .Include(x => x.City)
                        .Include(x => x.District)
                        .Include(x => x.Company)
                        .Include(x => x.CaravanRentOffers)
                        .Include(x => x.Images)
                        .Skip(skip)
                        .Take(pageSize)
                        .ToListAsync();
        }

        public async Task<Caravan> UpdateCaravan(Caravan entity)
        {
            await _context.SaveChangesAsync();
            
            var returnCaravan = await GetCaravanById(entity.Id);
            return returnCaravan;
        }

    }
}
