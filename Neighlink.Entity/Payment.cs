using System;

namespace Neighlink.Entity
{
    public class Payment :BaseEntity
    {
        public int Amount {get;set;}
        public DateTime PaymentDate {get;set;}
        public string Photo {get;set;}
        public virtual int BillId { get; set; }
        public virtual int UserId { get; set; }
    }
}