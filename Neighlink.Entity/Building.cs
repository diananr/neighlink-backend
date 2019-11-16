using System.Collections.Generic;

namespace Neighlink.Entity
{
    public class Building:BaseEntity
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public int NumberOfHomes { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
        public virtual ICollection<User> Users { get; set; }

    }
}