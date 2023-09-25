using AutoMapper;
using karavana_APPLICATION.InfraAbstractions;
using karavana_APPLICATION.ServiceAbstractions;
using karavana_CONTRACTS.DTOs.User;
using karavana_DOMAIN.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace karavana_APPLICATION.ServiceImplementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;
        private readonly ITokenHelper _tokenHelper;
        private readonly IMapper _mapper;
        public UserService(IUserRepository repo, ITokenHelper tokenHelper, IMapper mapper)
        {
            _repo = repo;
            _tokenHelper = tokenHelper;
            _mapper = mapper;
        }
        public async Task<UserDto> CreateUser(CreateUserRequest request)
        {
            var user = new User(
                firstName: request.FirstName,
                lastName: request.LastName,
                address: null,
                profilePictureUrl: null,
                email: request.Email,
                userRole: request.UserRole
                );

            var createdUser = await _repo.CreateUser(user, request.Password);
            var token = _tokenHelper.GenerateAccessToken(createdUser.Id, createdUser.Email);

            var userDto = _mapper.Map<UserDto>(createdUser);
            userDto.AccessToken = token;
            
            return userDto;
        }
    }
}
