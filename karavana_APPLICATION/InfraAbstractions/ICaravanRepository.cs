using karavana_CONTRACTS.DTOs.Caravan;
using karavana_DOMAIN.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace karavana_APPLICATION.InfraAbstractions
{
    public interface ICaravanRepository
    {
        Task<Caravan?> GetCaravanById(int id);
        Task<Caravan> CreateCaravan(Caravan entity);
    }
}
