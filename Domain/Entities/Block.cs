namespace Domain.Entities
{
    public class Block : IEntity
    {
        public int Id { get; set; }
        public string FloodId { get; set; }
        public virtual Floor Floor { get; set; } = null!;

        public List<Floor>? Floors { get; set; }


    }
}