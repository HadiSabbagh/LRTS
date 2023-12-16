using Application.Interfaces.Repositories;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LRTS.Controllers
{
    public abstract class GenericController<TEntity, TRepository> : Controller
        where TEntity : class, IEntity
        where TRepository : IRepository<TEntity>
    {
        private readonly TRepository _repository;
        

        public GenericController(TRepository repository)
        {
            _repository = repository;
            
        }


        // GET: Entity
        [HttpGet]
        public async Task<ActionResult<List<TEntity>>> Index()
        {
            try
            {
                var list = await _repository.GetAll();
                return View(list);

            }
            catch (InvalidOperationException e)
            {
//                _toastNotification.AddInfoToastMessage(e.Message);
                return View();
            }
        }

        // GET: Entity/Create
        public virtual IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TEntity entity)
        {
            try
            {
                await _repository.Create(entity);
              //  _toastNotification.AddSuccessToastMessage("Success!");
                return RedirectToAction(nameof(Index));

            }
            catch (DbUpdateException e)
            {
                //_toastNotification.AddErrorToastMessage("Failed to create. Make sure you are selecting valid values.");
                return View();
            }
        }



        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id cannot be null");
            }
            else
            {
                var entity = await _repository.FindById(id);
                if (entity == null)
                {
                   // _toastNotification.AddErrorToastMessage("Not found!");
                    return NotFound();
                }
                return View(entity);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, TEntity entity)
        {
            if (id != entity.Id)
            {
                return NotFound();
            }
            try
            {
                await _repository.Update(entity);
               // _toastNotification.AddSuccessToastMessage("Updated successfully.");
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException e)
            {
                //_toastNotification.AddErrorToastMessage("Failed to update. Make sure you select the valid values.");
                return View();
            }
        }

        // GET: Entity/Details/id
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            //Check for null id
            //Look up entity with given id
            //Check if NotFound
            //if Found, return
            if (id == null)
            {
               // _toastNotification.AddErrorToastMessage("No id was supplied. Make sure you are sending an id.");
                return View(nameof(Index));
            }
            else
            {
                var found = await _repository.FindById(id);
                if (found == null)
                {
                  //  _toastNotification.AddErrorToastMessage("Entry with Id does not exist.");
                    return NotFound();
                }
                return View(found);
            }
        }

        // GET: Entity/Delete/id
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _repository.GetAll() == null)
            {
              //  _toastNotification.AddErrorToastMessage("No id was supplied. Make sure you are sending an id.");
                return View(nameof(Index));
            }
            var entity = await _repository.FindById(id);
            if (entity == null)
            {
              // _toastNotification.AddErrorToastMessage("Entry with Id does not exist.");
                return NotFound();
            }
            return View(entity);
        }

        // DELETE: Entity/Delete/id
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_repository.GetAll() == null)
            {
                return Problem("Entity set is empty");
            }
            var entity = await _repository.FindById(id);
            if (entity != null)
            {
                await _repository.Delete(entity.Id);
               // _toastNotification.AddSuccessToastMessage("Deleted successfully.");

            }
            else
            {
              //  _toastNotification.AddErrorToastMessage("Entry with Id does not exist.");

            }
            return RedirectToAction(nameof(Index));

        }
    }
}
