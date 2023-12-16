using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SingleDesk : Desk
    {
        [Range(1, 1)]
        public new int DeskCapacity { get; set; }
        public int UserId { get; set; }

    }
}
