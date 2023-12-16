using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class GuestUser : User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int UniId { get; set; }

        public  University University { get; set; }

        public Reservation Reservation { get; set; }

        public bool HasAccess { get; set; }
        public UserType UserType { get; set; }

        public GuestUser(string name, int unId, bool hasAccess)
        {
            Name = name;
            UniId = unId;
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
