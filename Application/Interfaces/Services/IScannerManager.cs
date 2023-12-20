using Domain.Entities;
using System.Net.Http.Json;

namespace Application.Interfaces.Services
{
    public interface IScannerManager
    {
        public bool validateCard(int id);
        public Task<User?> getUserInformation(int id);
    }
}
