using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public interface User
    {
        public int Id { get; set; }
        public  string Name { get; set; }
        
        public int UniId { get; set; }

        public bool HasAccess { get; set; }
        public UserType UserType { get; set; }
    }
}
