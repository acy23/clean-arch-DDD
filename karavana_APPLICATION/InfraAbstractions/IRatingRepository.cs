using karavana_DOMAIN.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace karavana_APPLICATION.InfraAbstractions
{
    public interface IRatingRepository
    {
        Task<Rating> CreateRating(Rating entity);
        Task<Rating?> GetRatingById(int id);
        Task<Rating?> GetRatingsByCaravanRentOfferId(int caravanRentOfferId);
    }
}
