namespace Domain.Entities
{
    public class Floor : IEntity
    {
        public int Id { get; set; }
        public int BlockId { get; set; }
        public Block Block { get; set; }

        public ICollection<Desk>? Desks = new List<Desk>();
    }
}