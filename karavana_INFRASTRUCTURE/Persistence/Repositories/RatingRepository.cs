using karavana_APPLICATION.InfraAbstractions;
using karavana_DOMAIN.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace karavana_INFRASTRUCTURE.Persistence.Repositories
{
    public class RatingRepository : IRatingRepository
    {
        private readonly AppDbContext _context;
        public RatingRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Rating> CreateRating(Rating entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();

            var responseEntity = await GetRatingById(entity.Id);
            return responseEntity;
        }

        public async Task<Rating?> GetRatingById(int id)
        {
            var entity = await _context.Ratings.Where(x => x.Id == id && !x.IsDeleted).SingleOrDefaultAsync();
            return entity;
        }

        public async Task<Rating?> GetRatingsByCaravanRentOfferId(int caravanRentOfferId)
        {
            var entity = await _context.Ratings.Where(x => x.CaravanRentOfferId == caravanRentOfferId && !x.IsDeleted).SingleOrDefaultAsync();
            return entity;
        }
    }
}
