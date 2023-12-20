using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public float PenaltyScore { get; set; }
        public int UniversityId { get; set; }
        public University? University { get; set; }

        public int? ReservationId { get; set; } = null;
        public Reservation? Reservation { get; set; }
        public bool HasAccess { get; set; }
        [EnumDataType(typeof(UserType))]
        public UserType UserType { get; set; }
        [EnumDataType(typeof(UserStatus))]
        public UserStatus CurrentUserStatus { get; set; }
        [EnumDataType(typeof(UserStatus))]
        public UserStatus PreviousUserStatus { get; set; }

        public User( string name, int universityId, int? reservationId, bool hasAccess, UserType userType, UserStatus currentUserStatus, UserStatus previousUserStatus)
        {
            Name = name;
            UniversityId = universityId;
            ReservationId = reservationId;
            HasAccess = hasAccess;
            UserType = userType;
            CurrentUserStatus = currentUserStatus;
            PreviousUserStatus = previousUserStatus;
            PenaltyScore = 0;
        }
    }
}
