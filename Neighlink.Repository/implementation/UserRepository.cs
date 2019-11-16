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
            var user = context.users.Where(x => x.Email == email).FirstOrDefault();

            // No encontramos el usuario
            if (user == null)
                return null;

            byte[] incoming = CustomLoginProviderUtils
                        .hash(password, user.Salt);

            // El password no era correcto
            if (!CustomLoginProviderUtils.slowEquals(incoming, user.SaltedAndHashedPassword))
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

            //Quitar cosas sensibles
            user.SaltedAndHashedPassword = null;
            user.Salt = null;

            return user;
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

        public bool Save(User entity)
        {
            

            try
            {
                context.Add(entity);
                context.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        public bool Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
