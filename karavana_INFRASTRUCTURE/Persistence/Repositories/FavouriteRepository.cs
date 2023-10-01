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
    public class FavouriteRepository : IFavouriteRepository
    {
        private readonly AppDbContext _context;
        public FavouriteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Favourite> CreateFavourite(Favourite entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();

            var responseEntity = await GetFavouriteById(entity.Id);
            return responseEntity;
        }

        public async Task<Favourite?> GetFavouriteById(int id)
        {
            var entity = await _context.Favourites.Where(x => x.Id == id && !x.IsDeleted).SingleOrDefaultAsync();
            return entity;
        }

        public async Task<Favourite?> GetFavouritesByCaravanRentOfferId(int caravanRentOfferId)
        {
            var entity = await _context.Favourites.Where(x => x.CaravanRentOfferId == caravanRentOfferId 
                                                          && !x.IsDeleted)
                        .SingleOrDefaultAsync();
            return entity;
        }
    }
}
