using System;
using System.Threading.Tasks;
using AutoMapper;
using testarossa.Core.Domain;
using testarossa.Core.Repositories;
using testarossa.Infrastructure.DTO;

namespace testarossa.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper) 
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDTO> Get(string email)
        {
            var user = await _userRepository.Get(email);

            return _mapper.Map<User,UserDTO>(user);
        }

        public async Task Register(string email, string username, string password)
        {
            var user = await _userRepository.Get(email);
            if (user != null)
                throw new Exception($"User with email: '{email}' already exists.");
            var salt = Guid.NewGuid().ToString("N");    
            user = new User(email, username, password, salt);
            await _userRepository.Add(user);
            await Task.CompletedTask;
        }

        
    }
}