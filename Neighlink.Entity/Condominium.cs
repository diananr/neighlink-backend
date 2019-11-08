using System;
using System.Collections.Generic;
using Neighlink.Entity.Entity;

namespace Neighlink.Entity
{
    public class Condominium : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhotoUrl { get; set; }
        public string SecretCode { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<Poll> Polls { get; set; }
        public virtual ICollection<Bill> Billss { get; set; }
        public virtual ICollection<Building> Buildings { get; set; }
        public virtual ICollection<PaymentCategory> PaymentCategories { get; set; }
        public virtual ICollection<New> News { get; set; }
    }
}
