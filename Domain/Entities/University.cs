namespace Domain.Entities
{
    public class University : IEntity
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int LibraryId { get; set; }

        public virtual Library Library { get; set; } = null!;

        public ICollection<Library>? Libraries = new List<Library>();
    }
}