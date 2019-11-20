using System;

namespace Neighlink.Entity
{
    public class Bill :BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Amount { get; set; }
        public DateTime StartDate { get; set; } = new DateTime(2019, 08, 25);
        public DateTime EndDate { get; set; } = new DateTime(2019, 08, 25);
        public PaymentCategory PaymentCategory_id{get;set;}
        public Building Building_id{get;set;}
    }
}