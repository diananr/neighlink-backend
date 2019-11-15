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
        
        ////////////////////////////////////////////FK
        public Building building {get;set;}
        public Role role {get;set;}
    }
}