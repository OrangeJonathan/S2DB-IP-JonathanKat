using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollectiblesCore;

namespace GameCollectiblesCore.Users
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        

        public UserService(IUserRepository repository)
        {
            _userRepository = repository;
        }

        public IEnumerable<User> GetAllUsers()
        {
            IEnumerable<User> users = _userRepository.GetAllUsers();
            return users;
        }
        

    }
}
