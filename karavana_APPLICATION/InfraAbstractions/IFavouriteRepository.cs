using karavana_DOMAIN.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace karavana_APPLICATION.InfraAbstractions
{
    public interface IFavouriteRepository
    {
        Task<Favourite> CreateFavourite(Favourite entity);
        Task<Favourite?> GetFavouriteById(int id);
        Task<Favourite?> GetFavouritesByActiveCaravanPlaceId(int activeCaravanPlaceId);
    }
}
