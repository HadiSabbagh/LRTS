using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Persistance.RepositoriesImpl;

namespace LRTS.Controllers
{
    public class UniversitiesController : GenericController<University, UniversitiesRepository>
    {
        public UniversitiesController(UniversitiesRepository universitiesRepository) : base(universitiesRepository)
        {

        }
    }
}
