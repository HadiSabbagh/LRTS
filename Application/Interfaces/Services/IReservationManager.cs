using Domain.Entities;


namespace Application.Interfaces.Services
{
    public interface IReservationManager
    {

        public Task<DeskStatus> checkDeskStatusAsync(int deskId);
        public Task<Reservation> createReservation(int userId, int deskId, DateTime startDate, DateTime endDate);
        public Task cancelReservation(Reservation reservation, ReservationStatus reservationStatus);
        public Task<ReservationStatus> updateReservation(Reservation reservation);
        

        public bool checkCurrentUserStatus(User user, UserStatus currentUserStatus);
        public bool checkPreviousUserStatus(User user, UserStatus previousUserStatus);
        public Task<List<Desk>> emptyDisksAsync();

        public Task updateDeskStatus(Desk desk, DeskStatus deskStatus);
        public Task updateReservationStatus(Reservation reservation, ReservationStatus reservationStatus);
        public Task updateUserStatus(User user, Reservation reservation);

        public Task<Reservation?> getReservationByUserId(int userId);




    }
}
