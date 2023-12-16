using BenchWeb.Repositories;
using Domain.Entities;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.RepositoriesImpl
{
    public class UniversitiesRepository : CoreRepository<University, LRTSContext>
    {
        private readonly LRTSContext _context;
        public UniversitiesRepository(LRTSContext context) : base(context)
        {
            _context = context;
        }
    }
}
