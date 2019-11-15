using System;

namespace Neighlink.Entity
{
    public class News:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset Date { get; set; } = new DateTime(2019, 08, 25);
    }
}