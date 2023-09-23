using AutoMapper;
using karavana_APPLICATION.InfraAbstractions;
using karavana_APPLICATION.ServiceAbstractions;
using karavana_CONTRACTS.DTOs.Caravan;
using karavana_DOMAIN.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace karavana_APPLICATION.ServiceImplementations
{
    public class CaravanService : ICaravanService
    {
        private readonly ICaravanRepository _repo;
        private readonly IMapper _mapper;

        public CaravanService(ICaravanRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<CaravanDTO> CreateCaravan(CreateCaravanRequest request)
        {
            var entity = new Caravan
                (request.Name,
                 request.Price,
                 request.Currency,
                 request.FuelType,
                 request.CaravanType,
                 request.City,
                 request.District);

            var caravan = await _repo.CreateCaravan(entity);
            var caravanDto = _mapper.Map<CaravanDTO>(caravan);
            return caravanDto;
        }

        public async Task<CaravanDTO> GetCaravanById(int id)
        {
            var caravan = await _repo.GetCaravanById(id);
            if(caravan == null)
            {
                return null;
            }

            var caravanResponse = _mapper.Map<CaravanDTO>(caravan);
            return caravanResponse;
        }

    }
}
