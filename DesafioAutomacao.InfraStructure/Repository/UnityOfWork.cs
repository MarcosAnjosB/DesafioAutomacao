using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data;
using System.Linq.Expressions;
using System.Data.Entity.Core;
using System.Data.Entity.Validation;
using DesafioAutomacao.InfraStructure.InfraStructure.Repository;

namespace DesafioAutomacao.InfraStructure.Repository
{
    public class UnityOfWork : IUnityOfWork
    {
        #region Fields
        public DbContext Context { get; private set; }
        #endregion

        #region Constructors
        public UnityOfWork(DbContext context)
        {
            Context = context;
        }
        #endregion

        #region Public Methods
        public TEntity FindById<TEntity>(params object[] keyValues) where TEntity : class
        {
            return Context.Set<TEntity>().Find(keyValues);
        }

        public IQueryable<TEntity> QueryableFor<TEntity>() where TEntity : class
        {
            return Context.Set<TEntity>().AsQueryable();
        }

        public IQueryable<TEntity> QueryableFor<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class
        {
            return Context.Set<TEntity>().Where(criteria);
        }

        public TEntity Add<TEntity>(TEntity entity) where TEntity : class
        {
            Context.Set<TEntity>().Add(entity);
            Context.SaveChanges();
            return entity;
        }

        public TEntity Update<TEntity>(TEntity entity) where TEntity : class
        {
            try
            {
                Context.Entry<TEntity>(entity).State = System.Data.Entity.EntityState.Modified;
                Context.SaveChanges();
            }
            catch (OptimisticConcurrencyException)
            {
                //Context.Entry<TEntity>(entity).(RefreshMode.ClientWins, entity);
                //Context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                string erro = string.Empty;
                foreach (var eve in e.EntityValidationErrors)
                {
                    erro += string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                       erro += string.Format("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            return entity;
        }

        public T Update<T, U>(T entity, ICollection<U> list)
            where T : class
            where U : class
        {
            try
            {
                Context.Entry<T>(entity).State = System.Data.Entity.EntityState.Modified;

                foreach (var item in list)
                {
                    Context.Entry<U>(item).State = System.Data.Entity.EntityState.Modified;
                }

                Context.SaveChanges();
            }
            catch (OptimisticConcurrencyException)
            {
                //Context.Entry<TEntity>(entity).(RefreshMode.ClientWins, entity);
                //Context.SaveChanges();
            }
            return entity;
        }

        public TEntity Remove<TEntity>(TEntity entity) where TEntity : class
        {
            Context.Set<TEntity>().Attach(entity);
            Context.Set<TEntity>().Remove(entity);
            Context.SaveChanges();
            return entity;
        }
        #endregion
    }
}
