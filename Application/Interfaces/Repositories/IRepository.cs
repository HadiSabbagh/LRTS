using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IRepository<T> where T : IEntity
    {
        //Return list of entity data
        Task<List<T>> GetAll();

        //Return an entity by id
        Task<T> FindById(int? id);

        //Add an entity
        Task<T> Create(T entity);

        //Update an entity

        Task<T> Update(T entity);

        //Delete an entity by id
        Task Delete(int id);

        //For composite primary keys
        Task<T> FindByIdComposite(object[] keyValues);
    }
}
