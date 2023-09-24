using karavana_DOMAIN.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace karavana_APPLICATION.InfraAbstractions
{
    public interface IUserRepository
    {
        Task<User> CreateUser(User user, string password);
        Task<User?> GetUserById(string userId);
    }
}
