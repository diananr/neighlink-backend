using System;
using System.Collections.Generic;
using System.Text;

namespace Neighlink.Entity
{
    public class UserInformation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string BuildingName { get; set; }
        public string UserRole { get; set; }
    }
}
