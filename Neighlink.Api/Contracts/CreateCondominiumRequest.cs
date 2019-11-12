using Neighlink.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neighlink.Api.Contracts
{
    public class CreateCondominiumRequest
    {
        public Condominium Condominium { get; set; }
        public int PlanId { get; set; }
    }
}
