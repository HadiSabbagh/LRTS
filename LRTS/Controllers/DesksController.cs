using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Persistance.RepositoriesImpl;

namespace LRTS.Controllers
{
    public class DesksController : GenericController<Desk, DesksRepository>
    {

        public DesksController(DesksRepository desksRepository) : base(desksRepository)
        {
        }

    }
}
