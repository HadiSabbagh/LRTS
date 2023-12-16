using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Persistance.RepositoriesImpl;

namespace LRTS.Controllers
{
    public class UsersController : GenericController<User, UsersRepository>
    {
        public UsersController(UsersRepository usersRepository) : base(usersRepository)
        {
         
        }
       

    }
}
