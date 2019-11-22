using System;
using System.Collections.Generic;

namespace Neighlink.Entity.Entity
{
    public class Poll: BaseEntity
    {
         public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset StarDate { get; set; } = new DateTime(2019,08,25);
        public DateTimeOffset EndDate { get; set; } = new DateTime(2019, 08, 25);

        public virtual ICollection<Option> Options { get; set; }
        public virtual int CondominiumId { get; set; }
    }
}