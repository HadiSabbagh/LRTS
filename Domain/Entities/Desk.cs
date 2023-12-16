namespace Domain.Entities
{
    public class Desk : IEntity
    {
        public int Id { get; set; }
        public int UniId { get; set; }
        public DeskStatus DeskStatus { get; set; }

        public int DeskCapacity { get; set; }
    }
}