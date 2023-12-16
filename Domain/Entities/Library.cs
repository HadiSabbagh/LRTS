namespace Domain.Entities
{
    public class Library : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BlockId { get; set; }

        public virtual Block Block { get; set; } = null!;

        public ICollection<Block>? Blocks = new List<Block>();

        public virtual University University { get; set; } = null!;
    }
}