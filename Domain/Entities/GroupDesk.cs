using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class GroupDesk : Desk
    {
        [Range(2, 6)]
        public new int DeskCapacity { get; set; }

        public required List<User> Users  = new List<User>();
    }
}
