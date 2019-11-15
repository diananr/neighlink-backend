
using Neighlink.Entity.Entity;

namespace Neighlink.Entity
{
    public class Condominium : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhotoUrl { get; set; }
        public string SecretCode { get; set; }

        ////////////////////////////////////////////FK
        public Role role {get;set;}
        public Poll poll {get;set;}
        public Bill bill {get;set;}
        public Building building {get;set;}
        public PaymentCategory paymentCategory {get;set;}
        public News news {get;set;}
            
    }
}
