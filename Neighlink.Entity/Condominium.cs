
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
        public int RoleId {get;set;}
        public Role role {get;set;}
        public int PollId {get;set;}
        public Poll poll {get;set;}
        public int BillId {get;set;}
        public Bill bill {get;set;}
       
        public int BuildingId {get;set;}
        public Building building {get;set;}
        public int PaymentCategoriesId {get;set;}
        public PaymentCategory paymentCategory {get;set;}
        public int NewsId {get;set;}
        public News news {get;set;}
            
    }
}
