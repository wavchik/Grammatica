using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using KakPishetsya.Common.Data.Context;
using KakPishetsya.Common.Data.Models;

namespace KakPishetsya.Common.Data.Repositories
{
    public abstract class BaseRepository<T>
        where T : BaseModel
    {
        protected readonly GrammaticaContext _context = new GrammaticaContext();

        public abstract IQueryable<T> All { get; }

        public abstract void AddNewEntity(T model);

        public abstract void Delete(int id);

        public virtual void InsertOrUpdate(T model)
        {
            if (model.Id == default(int))
            {
                AddNewEntity(model);
            }
            else
            {
                UpdateExistingEntity(model);
            }
        }

        public virtual IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = All;
            return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        public virtual T Find(int id)
        {
            return All.FirstOrDefault(x => x.Id.Equals(id));
        }

        public virtual IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return All.Where(predicate);
        }

        public virtual IQueryable<T> QueryBy(Expression<Func<T, bool>> predicate)
        {
            return All.Where(predicate);
        }

        public virtual void UpdateExistingEntity(T model)
        {
            _context.Entry(model).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}