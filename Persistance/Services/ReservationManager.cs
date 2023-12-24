using Application.Interfaces.Services;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Services
{
    public class ReservationManager : IReservationManager
    {
        private readonly LRTSContext _context;
        public ReservationManager(LRTSContext context)
        {
            _context = context;
        }
        public async Task<DeskStatus> checkDeskStatusAsync(int deskId)
        {
            var desk = await _context.Desks.FindAsync(deskId);
            if (desk == null)
            {
                return DeskStatus.UNUSABLE;
            }
            return desk.DeskStatus;
        }
        public async Task<Reservation> createReservation(int userId, int deskId, DateTime startDate, DateTime endDate)
        {
            Reservation reservation = new Reservation(userId, deskId, startDate, endDate, ReservationStatus.IS_ACTIVE);
            await _context.SaveChangesAsync();
            return reservation;
        }

        public async Task cancelReservation(Reservation reservation, ReservationStatus reservationStatus) // ENDED OR CANCELED
        {
            var user = _context.Users.Find(reservation.UserId);
            var desk = _context.Desks.Find(reservation.DeskId);
            if (desk != null || user != null)
            {
                await updateDeskStatus(desk, DeskStatus.EMPTY);
                await updateReservationStatus(reservation, reservationStatus);
                await updateUserStatus(user, reservation);
            }

        }

        public async Task<ReservationStatus> updateReservation(Reservation reservation)
        {
            var startTime = reservation.StartDateTime;
            var endTime = reservation.EndDateTime;
            var now = DateTime.Now;
            var user = _context.Users.Find(reservation.UserId);
            var desk = _context.Desks.Find(reservation.DeskId);

            if (desk == null || user == null)
            {
                // if no desk was registered with the reservation or doesn't have a user, cancel it
                await updateReservationStatus(reservation, ReservationStatus.CANCELED);
            }
            else
            {

                if (now > startTime
                    && checkPreviousUserStatus(user, UserStatus.OUTSIDE)
                    && checkCurrentUserStatus(user, UserStatus.OUTSIDE))
                {
                    // cancel reservation
                    await cancelReservation(reservation, ReservationStatus.CANCELED);
                }
                else if (now <= startTime
                    && checkPreviousUserStatus(user, UserStatus.OUTSIDE)
                    && checkCurrentUserStatus(user, UserStatus.IN_LIBRARY))
                {
                    // begin reservation
                    await updateDeskStatus(desk, DeskStatus.OCCUPIED);
                    await updateReservationStatus(reservation, ReservationStatus.IN_PROGRESS);
                }
                else if (now < endTime
                    && checkPreviousUserStatus(user, UserStatus.IN_LIBRARY)
                    && checkCurrentUserStatus(user, UserStatus.IN_BREAK)
                    )
                {
                    // check break conditions
                    if (reservation.RemainingBreakTimeInMinutes > 0)
                    {
                        reservation.StartBreak = DateTime.Now;
                    }
                    else //remaining break time is done, cancel reservation
                    {
                        await cancelReservation(reservation, ReservationStatus.CANCELED);

                    }
                }
                else if (now < endTime
                    && checkPreviousUserStatus(user, UserStatus.IN_BREAK)
                    && checkCurrentUserStatus(user, UserStatus.IN_LIBRARY))
                {
                    //user returned
                    reservation.EndBreak = DateTime.Now;
                    reservation.RemainingBreakTimeInMinutes -= (reservation.EndBreak - reservation.StartBreak).Value.Minutes;
                }
                else if (now >= reservation.EndBreak)
                {
                    await cancelReservation(reservation, ReservationStatus.CANCELED);
                }
                if (now >= endTime)
                {
                    //reservation ended
                    await cancelReservation(reservation, ReservationStatus.ENDED);
                }
                await _context.SaveChangesAsync();
            }
            return reservation.ReservationStatus;
        }
        public bool checkCurrentUserStatus(User user, UserStatus currentUserStatus)
        {
            if (user.CurrentUserStatus == currentUserStatus)
                return true;
            else
                return false;
        }

        public bool checkPreviousUserStatus(User user, UserStatus previousUserStatus)
        {
            if (user.PreviousUserStatus == previousUserStatus)
                return true;
            else
                return false;
        }

        public async Task<List<Desk>> emptyDisksAsync()
        {
            List<Desk> desks = await _context.Desks.Where(d => d.DeskStatus == DeskStatus.EMPTY).ToListAsync();
            if (desks.Count == 0)
            {
                // No empty desks! library is full!
            }
            return desks;
        }

        public async Task updateDeskStatus(Desk desk, DeskStatus deskStatus)
        {
            if (desk != null)
            {
                desk.DeskStatus = deskStatus;
            }

            await _context.SaveChangesAsync();
        }

        public async Task updateReservationStatus(Reservation reservation, ReservationStatus reservationStatus)
        {
            if (reservation != null)
            {
                reservation.ReservationStatus = reservationStatus;
            }
            await _context.SaveChangesAsync();

        }

        public async Task updateUserStatus(User user, Reservation reservation)
        {
            if (user != null)
            {


                if (user.CurrentUserStatus == UserStatus.OUTSIDE || user.CurrentUserStatus == UserStatus.IN_BREAK)
                {
                    user.PreviousUserStatus = user.CurrentUserStatus; // Save the previous status before updating the current status.
                    user.CurrentUserStatus = UserStatus.IN_LIBRARY;
                }
                else if (user.CurrentUserStatus == UserStatus.IN_LIBRARY)
                {

                    if (reservation == null)
                    {
                        user.PreviousUserStatus = UserStatus.OUTSIDE;
                        user.CurrentUserStatus = UserStatus.OUTSIDE;
                    }
                    else
                    {
                        if (reservation.ReservationStatus == ReservationStatus.IN_PROGRESS)
                        {
                            user.PreviousUserStatus = user.CurrentUserStatus;
                            if (reservation.RemainingBreakTimeInMinutes > 0)
                            {
                                user.CurrentUserStatus = UserStatus.IN_BREAK;
                            }
                        }
                        else
                        {
                            user.PreviousUserStatus = UserStatus.OUTSIDE;
                            user.CurrentUserStatus = UserStatus.OUTSIDE;
                        }
                    }
                }
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Reservation?> getReservationByUserId(int userId)
        {
            Reservation reservation = await _context.Reservations.FirstOrDefaultAsync(x => x.UserId == userId && (x.ReservationStatus == ReservationStatus.IS_ACTIVE
            || x.ReservationStatus == ReservationStatus.IN_PROGRESS));
            return reservation;
        }
    }
}
