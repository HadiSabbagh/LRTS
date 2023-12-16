namespace Domain.Entities
{
    public class Block : IEntity
    {
        public int Id { get; set; }
        public int LibraryId { get; set; }
        public Library? Library { get; set; }

        public ICollection<Floor>? Floors { get; set; } = new List<Floor>();

    }
}