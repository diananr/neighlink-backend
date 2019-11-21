using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Neighlink.Entity;
using Neighlink.Repository.Context;
using Neighlink.Repository.Utilities;
using Microsoft.EntityFrameworkCore;
using Neighlink.Entity.Entity;

namespace Neighlink.Repository.implementation
{
    public class UserRepository : IUserRepository
    {
        private ApplicationDbContext context;
        private PrivateSettings settings;
        public UserRepository(ApplicationDbContext context, IOptions<PrivateSettings> settings)
        {
            this.context = context;
            this.settings = settings.Value;
        }

        public User Authenticate(string email, string password)
        {
            var user = context.Users.Where(x => x.Email == email).FirstOrDefault();

            if (user == null) return null;

            byte[] incoming = CustomLoginProviderUtils.Hash(password, user.Salt);

            if (!CustomLoginProviderUtils.SlowEquals(incoming, user.SaltedAndHashedPassword))
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(settings.AuthenticationSecret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, user.Email.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.SecurityToken = tokenHandler.WriteToken(token);

            user.SaltedAndHashedPassword = null;
            user.Salt = null;

            return user;
        }

        public bool RegisterOwner(User user, int buildingId) 
        {
            try
            {
                var matchingBuilding = context.Buildings.Where(x => x.Id == buildingId).FirstOrDefault();
                if(matchingBuilding.Users == null) matchingBuilding.Users = new List<User>();
                matchingBuilding.Users.Add(user);
                context.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        public bool RegisterAdmin(User user, int condominiumId)
        {
            try
            {
                var matchingCondo = context.Condominiums.Where(x => x.Id == condominiumId).FirstOrDefault();
                if(matchingCondo.Administrators == null) matchingCondo.Administrators = new List<User>();
                matchingCondo.Administrators.Add(user);
                context.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        public IEnumerable<User> GetUsersByCondominium(int condominiumId)
        {
            try
            {
                var buildings = context.Buildings.Include(x => x.Users).Where(y => y.CondominiumId == condominiumId);
                var users = buildings.SelectMany(x => x.Users);
                return users.Where(x => x.Role == Entity.Entity.Role.Owner);
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        public User Get(int id)
        {
            try
            {
                 var user = context.Users.Find(id);
                 return user;
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        public bool Update(User entity)
        {
            try
            {
                var user = context.Users.Find(entity.Id);

                user.Email = entity.Email;
                user.Name = entity.Name;
                user.LastName = entity.LastName;
                user.Gender = entity.Gender;
                user.PhoneNumber = entity.PhoneNumber;
                user.PhotoUrl = entity.PhotoUrl;
                user.Status = entity.Status;
                user.BuildingId = entity.BuildingId;

                context.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var user = context.Users.Find(id);
                context.Users.Remove(user);
                context.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public bool Save(User entity)
        {
            try{
                context.Add(entity);
                context.SaveChanges();
            }
            catch(System.Exception)
            {
                return false;
            }
            return true;
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool UserBelongsToCondominium(User user, int condominiumId)
        {
            if (user.Role == Role.Administrator)
            {
                var matchingCondo = context.Condominiums.Include(y => y.Administrators).Where(x => x.Id == condominiumId).FirstOrDefault();
                if (matchingCondo != null && matchingCondo.Administrators.Select(x => x.Id).Contains(user.Id)) 
                {
                    return true;
                }

                return false;
            }
            else 
            {
                var matchingCondo = context.Condominiums.Include(x => x.Buildings).Where(y => y.Id == condominiumId).FirstOrDefault();
                if (matchingCondo != null) 
                {
                    var allUsers = matchingCondo.Buildings.SelectMany(x => x.Users);
                    bool userBelongsToOneBuilding = allUsers.Select(x => x.Id).Contains(user.Id);
                    return userBelongsToOneBuilding;
                }

                return false;
            }
        }
    }
}