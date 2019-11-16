using System;
using System.Collections.Generic;
using System.Text;
using Neighlink.Entity;
using Neighlink.Repository;

namespace Neighlink.Service.Implementation
{
    public class UserService : IUserService
    {
        private IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public User Authenticate(string email, string password)
        {
            return userRepository.Authenticate(email, password);
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public bool Save(User entity)
        {
            return userRepository.Save(entity);
        }

        public bool Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
