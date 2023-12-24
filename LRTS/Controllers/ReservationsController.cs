using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistance.RepositoriesImpl;
using Persistance.Services;

namespace LRTS.Controllers
{
    public class ReservationsController : GenericController<Reservation, ReservationsRepository>
    {
        ReservationManager _reservationManager;
        DesksRepository _desksRepository;
        public ReservationsController(ReservationsRepository reservationsRepository, ReservationManager reservationManager, DesksRepository desksRepository) : base(reservationsRepository)
        {
            _reservationManager = reservationManager;
            _desksRepository = desksRepository;
        }

        [HttpPost]
        public async Task<String> addReservation(int deskId, DateTime startDateTime, DateTime endDateTime)
        {
            var desk = await _desksRepository.FindById(deskId);
            if(desk ==null)
            {
                return "No such desk was found!";
            }
            Reservation reservation = await _reservationManager.createReservation(1, deskId, startDateTime, endDateTime);
            if (reservation != null)
            {
                return "Success";
            }
            else
            {
                return "Reservation failed";
            }
            
        }

        [HttpDelete]
        public async Task<String> removeReservation(Reservation reservation)
        {
            await _reservationManager.cancelReservation(reservation, ReservationStatus.CANCELED);
            return "Removed reservation";
        }
    }
}
