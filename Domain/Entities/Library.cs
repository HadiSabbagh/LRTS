namespace Domain.Entities
{
    public class Library : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public int UniversityId { get; set; }
        public University? University { get; set; }

        public ICollection<Block>? Blocks = new List<Block>();

    }
}