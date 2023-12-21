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
        public async Task<IActionResult> CardScanned(int userId)
        {

            User user = await _scanner.getUserInformation(userId);
            if (user == null)
            {
                return NotFound();
            }
            
            
            Reservation reservation = await _reservationManager.getReservationByUserId(userId);
            if(reservation == null)
            {
                return NotFound(Json(user, "Does not have an active or in progress reservation"));
            }
            ReservationStatus rStatus = await _reservationManager.updateReservation(reservation);
            return Json(rStatus.ToString());
        }

    }
}
