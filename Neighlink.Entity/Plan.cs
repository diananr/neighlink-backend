
using Neighlink.Entity.Entity;

namespace Neighlink.Entity
{
    public class Plan:BaseEntity
    {
        
        public string Description { get; set; }
        public int NumberOfHomes { get; set; }
        public PlanType Type { get; set; }
        ////////////////////////////////////////////FK
        public Condominium condominium {get;set;}
    }
}