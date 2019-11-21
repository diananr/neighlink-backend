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

        public bool RegisterAdmin(User user, int condominiumId)
        {
            return userRepository.RegisterAdmin(user, condominiumId);
        }

        public bool RegisterOwner(User user, int buildingId)
        {
            return userRepository.RegisterOwner(user, buildingId);
        }

        public IEnumerable<User> GetUsersByCondominium(int condominiumId)
        {
            return userRepository.GetUsersByCondominium(condominiumId);
        }

        public User Get(int id)
        {
            return userRepository.Get(id);
        }

        public bool Update(User entity)
        {
            return userRepository.Update(entity);
        }

        public bool Delete(int id)
        {
            return userRepository.Delete(id);
        }

        public bool Save(User entity)
        {
           throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool UserBelongsToCondominium(User user, int condominiumId)
        {
            return userRepository.UserBelongsToCondominium(user, condominiumId);
        }
    }
}
