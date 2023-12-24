using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Persistance.Services;

namespace LRTS.Controllers
{
    public class ScannerController : Controller
    {
        private ReservationManager _reservationManager;
        private ScannerManager _scanner;
        public ScannerController(ReservationManager reservationManager, ScannerManager scanner)
        {
            _reservationManager = reservationManager;
            _scanner = scanner;
        }

        [HttpPost]
        public async Task<IActionResult> CardScanned(string cardId)
        {

            User user = await _scanner.getUserInformationByCardId(cardId);
            if (user == null)
            {
                return NotFound("User was not found");
            }
            
            
            Reservation reservation = await _reservationManager.getReservationByUserId(user.Id);
            if(reservation == null)
            {
                return NotFound("No active reservation was found.");
            }
            
            await _reservationManager.updateUserStatus(user, reservation);
            await _reservationManager.updateReservation(reservation);
            return Ok(
                "\nCurrent User Status: " + user.CurrentUserStatus +
                "\nPrevious User Status: " + user.PreviousUserStatus +
                "\nReservation Status:" + reservation.ReservationStatus + 
                "\nRemaining Break Time:" + reservation.RemainingBreakTimeInMinutes);
        }

    }
}
