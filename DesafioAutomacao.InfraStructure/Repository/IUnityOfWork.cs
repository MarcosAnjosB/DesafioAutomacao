using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;

namespace DesafioAutomacao.InfraStructure.InfraStructure.Repository
{
    public interface IUnityOfWork
    {
        DbContext Context { get; }
        TEntity FindById<TEntity>(params object[] keyValues) where TEntity : class;
        IQueryable<TEntity> QueryableFor<TEntity>() where TEntity : class;
        IQueryable<TEntity> QueryableFor<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class;
        TEntity Add<TEntity>(TEntity entity) where TEntity : class;
        TEntity Update<TEntity>(TEntity entity) where TEntity : class;
        TEntity Remove<TEntity>(TEntity entity) where TEntity : class;
        T Update<T, U>(T entity, ICollection<U> list)
            where T : class
            where U : class;
    }
}
