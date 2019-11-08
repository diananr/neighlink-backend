using System.Collections.Generic;
using Neighlink.Entity.Entity;

namespace Neighlink.Entity
{
    public class Role
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public UserRole Type { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}