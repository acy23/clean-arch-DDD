using karavana_CONTRACTS.DTOs.Caravan;
using karavana_DOMAIN.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace karavana_APPLICATION.InfraAbstractions
{
    public interface ICaravanRepository
    {
        Task<List<Caravan>> GetCaravansOnRentPagination(Expression<Func<Caravan, bool>> predicate, int page, int pageSize);
        Task<List<Caravan>> GetCaravans(Expression<Func<Caravan, bool>> predicate, int page, int pageSize);
        Task<Caravan?> GetCaravanById(int id);
        Task<Caravan> CreateCaravan(Caravan entity);
        Task<bool> IsCaravanOnRent(int id);
        Task<Caravan> UpdateCaravan(Caravan entity);
    }
}
