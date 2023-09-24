using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace karavana_APPLICATION.InfraAbstractions
{
    public interface ITokenHelper
    {
        string GenerateAccessToken(string userId, string email);
    }
}
