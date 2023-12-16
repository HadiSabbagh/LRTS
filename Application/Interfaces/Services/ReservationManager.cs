using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public class ReservationManager
    {
        public DeskStatus checkDeskStatus(int deskId)
        {
            throw new NotImplementedException();
        }

        public Reservation checkReservationStatus(Reservation reservation) { throw new NotImplementedException(); }

        public List<Desk> emptyDisks() { throw new NotImplementedException(); }

        public void updateDeskStatus(Desk desk) {  throw new NotImplementedException(); }

        public void checkUserArrival(User user) { throw new NotImplementedException(); }


    }
}
