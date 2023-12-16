using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AdminUser : User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int UniId { get; set; }

        public virtual University University { get; set; } = null!;

        public bool HasAccess { get; set; }
        public UserType UserType { get; set; }
      

        public AdminUser(string name, int unId, University university, bool hasAccess)
        {
            Name = name;
            UniId = unId;
            University = university;
            HasAccess = hasAccess;
            UserType = UserType.ADMIN;
            
        }


        public void registerUser(User user)
        {
            throw new NotImplementedException();
        }

        public void updateUser(User user)
        {
            throw new NotImplementedException();
        }
        public void deleteUser(User user)
        {
            throw new NotImplementedException();
        }

        public Reservation reserveDesk(int deskId,DateTime dateTime) 
        {
            throw new NotImplementedException();
        }

        public void cancelReservation(Reservation reservation) 
        {
            throw new NotImplementedException();
        }

        public void removeAccess(User user) 
        {
            user.HasAccess = false;
        }

    }
}
