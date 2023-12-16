namespace Domain.Entities
{
    public class Reservation : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public int DeskId { get; set; }

        public DateTime DateTime { get; set; }
        public Reservation(int userId, int deskId, DateTime dateTime) 
        {
            UserId = userId;
            DeskId = deskId;
            DateTime = dateTime;
        }

        public ICollection<User> Users { get; set; } = new List<User>();
        public ICollection<Desk> Desks { get; set; } = new List<Desk>();
    }
}