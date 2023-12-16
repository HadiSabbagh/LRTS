using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class StudentUser : User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int UniId { get; set; }

        public float PenaltyScore { get; set; }
        public virtual University University { get; set; } = null!;

        public bool HasAccess { get; set; }
        public UserType UserType { get; set; }

        public StudentUser(string name, float penaltyScore, int unId, University university, bool hasAccess)
        {
            Name = name;
            PenaltyScore = penaltyScore;
            UniId = unId;
            University = university;
            HasAccess = hasAccess;
            UserType = UserType.STUDENT;

        }


        public Reservation reserveDesk(int deskId, DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public void cancelReservation(Reservation reservation)
        {
            throw new NotImplementedException();
        }

    }
}
