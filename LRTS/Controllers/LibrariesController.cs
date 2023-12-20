using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Persistance.RepositoriesImpl;

namespace LRTS.Controllers
{
    public class LibrariesController : GenericController<Library,LibrariesRepository>
    {
        public LibrariesController(LibrariesRepository librariesRepository) : base(librariesRepository)
        {

        }
    }
}
