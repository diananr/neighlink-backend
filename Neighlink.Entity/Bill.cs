using System;

namespace Neighlink.Entity
{
    public class Bill :BaseEntity
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public float Cantidad { get; set; }
        public DateTime StartDate { get; set; } = new DateTime(2019, 08, 25);
        public DateTime EndDate { get; set; } = new DateTime(2019, 08, 25);

        ////////////////////////////////////////////FK
        public Building building {get;set;}
        public PaymentCategory paymentCategory{get;set;}
    }
}