using System.Collections.Generic;
using Neighlink.Entity.Entity;

namespace Neighlink.Entity
{
    public class Plan:BaseEntity
    {
        public virtual ICollection<Condominium> Condominiums { get; set; }
        public string Description { get; set; }
        public int NumberOfHomes { get; set; }
        public PlanType Type { get; set; }
    }
}