using System.Collections.Generic;
using Neighlink.Entity;
using Neighlink.Repository;

namespace Neighlink.Service.implementation
{
    public class RoleService : IRoleService
    {
        private IRoleRepository roleRepository;
        public RoleService(IRoleRepository roleRepository)
        {
            this.roleRepository=roleRepository;
        }
        public bool Delete(int id)
        {
            return roleRepository.Delete(id);
        }

        public Role Get(int id)
        {
            return roleRepository.Get(id);
        }

        public IEnumerable<Role> GetAll()
        {
            return roleRepository.GetAll();
        }

        public bool Save(Role entity)
        {
            return roleRepository.Save(entity);
        }

        public bool Update(Role entity)
        {
            return roleRepository.Update(entity);
        }
    }
}