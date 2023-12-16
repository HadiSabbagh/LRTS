namespace Domain.Entities
{
    public class Floor : IEntity
    {
        public int Id { get; set; }
        public int DeskId { get; set; }

        public ICollection<Desk>? Desks = new List<Desk>();
    }
}