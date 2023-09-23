using karavana_CONTRACTS.DTOs.Caravan;
using karavana_DOMAIN.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace karavana_APPLICATION.ServiceAbstractions
{
    public interface ICaravanService
    {
        Task<CaravanDTO> CreateCaravan(CreateCaravanRequest request);
        Task<CaravanDTO> GetCaravanById(int id);
    }
}
