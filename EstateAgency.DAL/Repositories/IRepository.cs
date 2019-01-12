using EstateAgency.DAL.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EstateAgency.DAL.Repositories
{
    public interface IRepository<TEntity> : IDisposable
        where TEntity : Entity

    {
        Task<TEntity> GetAsync(int id);

        IQueryable<TEntity> GetAll();

        void Delete(int id);

        Task AddAsync(TEntity entity);

        void Update(TEntity entity);

        Task<bool> ContainsEntityWithId(int id);
    }
}
