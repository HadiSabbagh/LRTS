using BenchWeb.Repositories;
using Domain.Entities;
using Persistance.Context;
using Persistance.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.RepositoriesImpl
{
    public class ReservationsRepository : CoreRepository<Reservation, LRTSContext>
    {

        private readonly LRTSContext _context;

        public ReservationsRepository(LRTSContext context) : base(context)
        {
            _context = context;
        }


    }
}
