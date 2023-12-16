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
    public class UsersRepository : CoreRepository<User,LRTSContext>
    {
        private readonly LRTSContext _context;
        public UsersRepository(LRTSContext context) : base(context)
        {
            _context = context;
        }
    }
}
