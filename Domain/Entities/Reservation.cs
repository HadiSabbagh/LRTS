using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Reservation : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public int DeskId { get; set; }

        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }

        public DateTime? StartBreak { get; set; } = null;
        public DateTime? EndBreak { get; set; } = null;

        public int  RemainingBreakTimeInMinutes { get; set; }
        [EnumDataType(typeof(ReservationStatus))]
        public ReservationStatus ReservationStatus { get; set; }
        public Reservation(int userId, int deskId, DateTime startDateTime, DateTime endDateTime, ReservationStatus reservationStatus)
        {
            UserId = userId;
            DeskId = deskId;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            RemainingBreakTimeInMinutes = 60;
            ReservationStatus = reservationStatus;
        }

        public ICollection<User> Users { get; set; } = new List<User>();
        public ICollection<Desk> Desks { get; set; } = new List<Desk>();
    }
}