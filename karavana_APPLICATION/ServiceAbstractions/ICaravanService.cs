using karavana_CONTRACTS.DTOs.CaravanRentOffer;
using karavana_CONTRACTS.DTOs.Caravan;
using karavana_DOMAIN.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using karavana_CONTRACTS.Models;
using karavana_CONTRACTS.DTOs.Caravan.Requests;

namespace karavana_APPLICATION.ServiceAbstractions
{
    public interface ICaravanService
    {
        Task<CaravanDTO> CreateCaravan(CreateCaravanRequest request);
        Task<CaravanDTO> GetCaravanById(int id);
        Task<CaravanDTO> SetCaravanOnRent(SetCravanOnRentRequest request);
        Task<List<CaravanDTO>> GetCaravansOnRentPagination(int page, int pageSize);
        Task<List<CaravanDTO>> GetCaravansByCompanyIdPagination(int companyId, int page, int pageSize);
        Task<CaravanDTO> UpdateCaravan(UpdateCaravanRequest request);


    }
}
