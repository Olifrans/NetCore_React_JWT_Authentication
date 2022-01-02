using AutoMapper;
using NetCoreReactJwt.BusinessManager.Interfaces;
using NetCoreReactJwt.Domain.Entities;
using NetCoreReactJwt.Domain.Shared.ModelViewsDtos.ClientDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreReactJwt.BusinessManager.Implementation
{
    public class UserBusinessManager : IUserBusinessManager
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserBusinessManager(IUserRepository userRepository, IMapper mapper)
        {
            this._userRepository = userRepository;
            this._mapper = mapper;
        }

        public User CreateUser(User create)
        {
            return _userRepository.CreateUser(create);
        }

        public async Task DeleteUsersAsync(int id)
        {
            await _userRepository.DeleteUsersAsync(id);
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _userRepository.GetUsersAsync();
        }

        public async Task<User> GetUsersIdAsync(int id)
        {
            return await _userRepository.GetUsersIdAsync(id);
        }

        public async Task<User> InsertUsersAsync(NewUser newUser)
        {
            var user = _mapper.Map<User>(newUser);
            return await _userRepository.InsertUsersAsync(user);
        }


        public async Task<User> UpdateUsersAsync(UpdateUser userUpdate)
        {
            var user = _mapper.Map<User>(userUpdate);
            return await _userRepository.UpdateUsersAsync(user);
        }
    }
}
