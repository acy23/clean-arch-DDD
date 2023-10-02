using AutoMapper;
using karavana_APPLICATION.InfraAbstractions;
using karavana_APPLICATION.ServiceAbstractions;
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
using ErrorOr;

namespace karavana_APPLICATION.ServiceImplementations
{
    public class CaravanService : ICaravanService
    {
        private readonly ICaravanRepository _repo;
        private readonly ICaravanRentOfferRepository _caravanRenfOfferRepo;
        private readonly IMapper _mapper;

        public CaravanService(ICaravanRepository repo, IMapper mapper, ICaravanRentOfferRepository caravanRenfOfferRepo)
        {
            _repo = repo;
            _mapper = mapper;
            _caravanRenfOfferRepo = caravanRenfOfferRepo;
        }

        public async Task<CaravanDTO> CreateCaravan(CreateCaravanRequest request)
        {
            var entity = new Caravan
                (
                    name: request.Name,
                    companyId: request.CompanyId,
                    fuelType: request.FuelType,
                    caravanType: request.CaravanType,
                    capacity: request.Capacity,
                    cityId: request.CityId,
                    districtId: request.DistrictId,
                    gearType: request.GearType,
                    description: request.Description
                 );

            var caravan = await _repo.CreateCaravan(entity);
            var caravanDto = _mapper.Map<CaravanDTO>(caravan);
            return caravanDto;
        }

        public async Task<CaravanDTO> GetCaravanById(int id)
        {
            var caravan = await _repo.GetCaravanById(id);
            var caravanResponse = _mapper.Map<CaravanDTO>(caravan);
            return caravanResponse;
        }

        public async Task<List<CaravanDTO>> GetCaravansByCompanyIdPagination(int companyId, int page, int pageSize)
        {
            var items = await _repo.GetCaravans(x => x.CompanyId == companyId && !x.IsDeleted, page, pageSize);

            var response = _mapper.Map<List<CaravanDTO>>(items);

            return response;
        }

        public async Task<List<CaravanDTO>> GetCaravansOnRentPagination(int page, int pageSize, CaravanQueryFilters filters)
        {
            var items = await _repo.GetCaravansOnRentPagination(x => !x.IsDeleted, page, pageSize, filters);

            var response = _mapper.Map<List<CaravanDTO>>(items);
            
            return response;
        }

        public async Task<CaravanDTO> SetCaravanOnRent(SetCravanOnRentRequest request)
        {
            if(await _repo.IsCaravanOnRent(request.CaravanId))
            {
                throw new Exception("caravan is on rent");
            }

            var caravanEntity = new CaravanRentOffer(caravanId: request.CaravanId,
                                                       price: request.Price,
                                                       currency: request.Currency,
                                                       placeStartDate: request.PlaceStartDate,
                                                       placeEndDate: request.PlaceEndDate); 

            var createdCaravanPlace = await _caravanRenfOfferRepo.CreateCaravanRentOffer(caravanEntity);
            var response = _mapper.Map<CaravanDTO>(createdCaravanPlace);

            return response;
        }

        public async Task<CaravanDTO> UpdateCaravan(UpdateCaravanRequest request)
        {
            var caravan = await _repo.GetCaravanById(request.Id);

            caravan.UpdateCaravan(caravan,
                                  Name: request.Name,
                                  Description: request.Description,
                                  FuelType: request.FuelType,
                                  CaravanType: request.CaravanType,
                                  GearType: request.GearType,
                                  Capacity: request.Capacity,
                                  CityId: request.CityId,
                                  DistrictId: request.DistrictId,
                                  CompanyId: request.CompanyId);
            

            var caravanUpdated = await _repo.UpdateCaravan(caravan);

            var updatedCaravanModel = _mapper.Map<CaravanDTO>(caravanUpdated);
            return updatedCaravanModel;
        }
    }
}
