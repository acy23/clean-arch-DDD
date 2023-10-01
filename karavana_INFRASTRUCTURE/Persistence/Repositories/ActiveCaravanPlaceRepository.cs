using karavana_APPLICATION.InfraAbstractions;
using karavana_CONTRACTS.DTOs.Caravan;
using karavana_DOMAIN.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace karavana_INFRASTRUCTURE.Persistence.Repositories
{
    public class CaravanRentOfferRepository : ICaravanRentOfferRepository
    {
        private readonly AppDbContext _context;
        private readonly ICaravanRepository _caravanRepo;
        public CaravanRentOfferRepository(AppDbContext context, ICaravanRepository caravanRepo)
        {
            _context = context;
            _caravanRepo = caravanRepo;
        }
        public async Task<Caravan?> CreateCaravanRentOffer(CaravanRentOffer entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();

            var responseEntity = await _caravanRepo.GetCaravanById(entity.CaravanId);
            return responseEntity;
        }


    }
}
