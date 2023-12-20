using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Persistance.Context;
using Persistance.Services;

namespace LRTS.Controllers
{
    public class HomeController : Controller
    {
        private readonly LRTSContext _context;
        private ReservationManager _reservationManager;
        public HomeController(LRTSContext context, ReservationManager reservationManager)
        {
            _context = context;
            _reservationManager = reservationManager;
        }
        public async Task<IActionResult> IndexAsync()
        {
            User user = new User("ahmet", 1, null, true, UserType.STUDENT, UserStatus.OUTSIDE, UserStatus.OUTSIDE);
            Reservation reservation = await _reservationManager.createReservation(10, 1, DateTime.Now.AddMinutes(1), DateTime.Now.AddMinutes(60));
            _context.Users.Add(user); 
            _context.Reservations.Add(reservation);
            _context.SaveChanges(); 
            return View();
        }
    }
}
