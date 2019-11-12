using Neighlink.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neighlink.Api.Contracts
{
    public class CreateDefaultUserRequest
    {
        public User User { get; set; }
        public int CondominiumId { get; set; }
    }
}
