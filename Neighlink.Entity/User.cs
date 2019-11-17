using Neighlink.Entity.Entity;

namespace Neighlink.Entity
{
    public class User :BaseEntity
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string PhotoUrl { get; set; }
        public byte[] Salt { get; set; }
        public byte[] SaltedAndHashedPassword { get; set; }
        public string SecurityToken { get; set; }
        public Role Role {get;set;}
        public int? BuildingId {get;set;}
    }
}