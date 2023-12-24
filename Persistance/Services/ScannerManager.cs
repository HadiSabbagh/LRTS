using Application.Interfaces.Services;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using System.Net.Http.Json;

namespace Persistance.Services
{
    public class ScannerManager : IScannerManager
    {
        private readonly LRTSContext _context;
        public ScannerManager(LRTSContext context)
        {
            _context = context;
        }

        public async Task<User?> getUserInformation(int id)
        {
            User user = await _context.Users.FindAsync(id);
            if(user == null)
            {
                return null;
            }
            return user;
        }
        public async Task<User?> getUserInformationByCardId(string cardId)
        {
            
            User user = await _context.Users.Where(x => x.CardId == cardId).FirstAsync();
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public bool validateCard(int id)
        {
            throw new NotImplementedException();
        }
    }
}
