using Neighlink.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neighlink.Api.Contracts
{
    public class CreateBuildingRequest
    {
        public Building Building { get; set; }
        public int CondominiumId { get; set; }
    }
}
