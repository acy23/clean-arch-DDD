﻿using karavana_CONTRACTS.DTOs.Caravan;
using karavana_CONTRACTS.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace karavana_APPLICATION.ServiceAbstractions
{
    public interface IUserService
    {
        Task<UserDto> CreateUser(CreateUserRequest request);
    }
}
