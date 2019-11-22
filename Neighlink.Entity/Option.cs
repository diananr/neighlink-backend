namespace Neighlink.Entity
{
    public class Option:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual int PollId { get; set; }
    }
}