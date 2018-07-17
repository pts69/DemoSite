using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DemoSite.Model;
using DemoSite.Model.Entities;

namespace DemoSite.Repository
{
    //Interface class
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate);
        T GetById(object id);
        T Add(T entity);
        T Delete(T entity);
        void Edit(T entity);
        void Save();
        int ExecuteRawSql(string command);
        IEnumerable<T> ExecueStoreProcedure(string storedProcedure, params object[] parameters);
    }

    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected MyDbContext _entities;
        protected readonly IDbSet<T> _dbset;

        public GenericRepository(MyDbContext context)
        {
            _entities = context;
            _dbset = (IDbSet<T>) context.Set<T>();
        }

        public virtual T GetById(object id)
        {
            return _dbset.Find(id);
        }

        public virtual IQueryable<T> GetAll()
        {
            return _dbset.AsQueryable<T>();
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            var query = _dbset.Where(predicate).AsQueryable();
            return query;
        }

        public IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate)
        {
            var query = _dbset.Where(predicate).AsQueryable();
            return query;
        }

        public IQueryable<T> FindAll(Expression<Func<T, bool>> predicate)
        {
            var query = _entities.Set<T>().Where(predicate);
            return query;
        }

        public virtual T Add(T entity)
        {

            try
            {
                _dbset.Add(entity);
            }
            catch (Exception ex)
            {
                return entity;
            }
            return entity;
        }

        public virtual T Delete(T entity)
        {
            _dbset.Attach(entity);
            return _dbset.Remove(entity);

        }

        public virtual void Edit(T entity)
        {
            try
            {
                _entities.Entry(entity).State = EntityState.Modified;
            }
            catch (DataException ex)
            {

            }
        }

        public virtual void Save()
        {
            _entities.SaveChanges();
        }

        public virtual int ExecuteRawSql(string command)
        {
            return _entities.Database.ExecuteSqlCommand(command);
        }

        public IEnumerable<T> ExecueStoreProcedure(string storedProcedure, params object[] parameters)
        {
            return _entities.Database.SqlQuery<T>(storedProcedure, parameters);
        }

    }
}
